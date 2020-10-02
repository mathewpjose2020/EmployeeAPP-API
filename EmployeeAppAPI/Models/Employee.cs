using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAppAPI.Models
{
    public class Employee
    {
        public int? id { get; set; }

        public string name { get; set; }

        public string password{ get; set; }

        public string gender { get; set; }

        public string email { get; set; }

        public long phoneNumber { get; set; }

        public string contactPreference { get; set; }

        public string dateOfBirth { get; set; }

        public string department { get; set; }

        public string isActive { get; set; }
        public string photoPath { get; set; }

        public string Token { get; set; }

    }
}