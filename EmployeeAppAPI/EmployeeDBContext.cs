using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EmployeeAppAPI.Models;

namespace EmployeeAppAPI
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext() : base("name=SchoolDBConnectionString")
        {
            //Database.SetInitializer<EmployeeDBContext>(new EmployeeDBInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeDBContext, EmployeeAppAPI.Migrations.Configuration>());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}