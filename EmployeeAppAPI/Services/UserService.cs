using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using EmployeeAppAPI.Models;
using EmployeeAppAPI.Helpers;

namespace EmployeeAppAPI.Services
{
    public interface IUserService
    {
        Employee Authenticate(string username, string password);
        //IEnumerable<Employee> GetAll();
    }

    public class UserService : IUserService
    {
        EmployeeDBContext DB = new EmployeeDBContext();

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<User> _users = new List<User>
        //{
        //    new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        //};

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Employee Authenticate(string username, string password)
        {
            var user = DB.Employees.SingleOrDefault(x => x.name == username && x.password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.password = null;

            return user;
        }

        //public IEnumerable<Employee> GetAll()
        //{
        //    // return users without passwords
        //    return DB.Employees.Select(x => {
        //        x.password = "";
        //        return x;
        //    });
        //}
    }
}