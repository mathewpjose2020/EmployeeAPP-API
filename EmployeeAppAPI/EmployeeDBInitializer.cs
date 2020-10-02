using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EmployeeAppAPI
{
    public class EmployeeDBInitializer : DropCreateDatabaseAlways<EmployeeDBContext>
    {
        protected override void Seed(EmployeeDBContext context)
        {
            base.Seed(context);
        }
    }
}