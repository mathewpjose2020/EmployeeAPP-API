using EmployeeAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeAppAPI.Controllers
{
    //[EnableCors("*", "*", "*")]
    //[EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        EmployeeDBContext DB = new EmployeeDBContext();

        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            return
                    (
                        from obj in DB.Employees
                        select new
                        {
                            id = obj.id,
                            name = obj.name,
                            gender = obj.gender,
                            email = obj.email,
                            phoneNumber = obj.phoneNumber,
                            contactPreference = obj.contactPreference,
                            dateOfBirth = obj.dateOfBirth,
                            department = obj.department,
                            isActive = obj.isActive,
                            photoPath = obj.photoPath,
                            password = obj.password

                        }
                    ).ToList();
        }

        public object Get(int id)
        {
            return
                    (
                        from obj in DB.Employees
                        where obj.id == id
                        select new
                        {
                            id = obj.id,
                            name = obj.name,
                            gender = obj.gender,
                            email = obj.email,
                            phoneNumber = obj.phoneNumber,
                            contactPreference = obj.contactPreference,
                            dateOfBirth = obj.dateOfBirth,
                            department = obj.department,
                            isActive = obj.isActive,
                            photoPath = obj.photoPath,
                            password = obj.password

                        }
                    ).FirstOrDefault();
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(string name, string password)
        {
            DB = new EmployeeDBContext();

            var log = DB.Employees.Where(x => x.name.ToUpper().Equals(name.ToUpper())
                    && x.password.ToUpper().Equals(password.ToUpper())).FirstOrDefault();


            if (log == null)

            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            }

            else

                return Request.CreateResponse(HttpStatusCode.OK, "Logged in Successfully");
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(Employee Employee)

        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                DB.Employees.Add(Employee);
                DB.SaveChanges();
                return Ok(Employee);
            }

        }

        [HttpPut]
        public IHttpActionResult Put(int id,Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employee objEmp = new Employee();
                objEmp = DB.Employees.Find(id);
                if (objEmp != null)
                {
                    objEmp.name = employee.name;
                    objEmp.gender = employee.gender;
                    objEmp.email = employee.email;
                    objEmp.phoneNumber = employee.phoneNumber;
                    objEmp.contactPreference = employee.contactPreference;
                    objEmp.dateOfBirth = employee.dateOfBirth;
                    objEmp.department = employee.department;
                    objEmp.isActive = employee.isActive;
                    objEmp.photoPath = employee.photoPath;
                }
                var i = this.DB.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }

            // DELETE api/<controller>/5
            public IHttpActionResult Delete(int id)
            {
                Employee employee = DB.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                DB.Employees.Remove(employee);
                DB.SaveChanges();

                return Ok(employee);
            }
    }
}