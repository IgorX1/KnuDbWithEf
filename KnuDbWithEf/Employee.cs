using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNUdb
{
    abstract class Employee
    {
        public string Name { get; set;}
        public string Email { get; set; }
        public string Department { get; set; }
        public string Cathedra { get; set; }
        public string Degree { get; set; }
        public string Year { get; set; }
        public string Rating { get; set; }
        public byte[] Photo { get; set; }

        public Employee()
        {
            Name = Email = Department = Cathedra = Rating = String.Empty;
            Photo = null;
        }
    }
}
