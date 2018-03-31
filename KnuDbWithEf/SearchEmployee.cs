using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnuDbWithEf
{
    class SearchEmployee : Employee
    {
        private DataGridView dgv;
        private EmployeeEf.KNUDBEntities ctx;
        public SearchEmployee(TextBox name,
                             TextBox depart,
                             TextBox cathedra,
                             TextBox email,
                             TextBox degree,
                             TextBox rating,
                             TextBox year,
                             DataGridView dgv,
                             EmployeeEf.KNUDBEntities ctx)
        {
            Name = name.Text;
            Department = depart.Text;
            Cathedra = cathedra.Text;
            Email = email.Text;
            Degree = degree.Text;
            Rating = rating.Text;
            Year = year.Text;
            this.ctx = ctx;
            this.dgv = dgv;
        }

        public void Search()
        {
            if (Name == String.Empty &&
                Department == String.Empty &&
                Cathedra == String.Empty &&
                Email == String.Empty &&
                Degree == String.Empty &&
                Rating == String.Empty &&
                Year == String.Empty)
            {
                MessageBox.Show("Заповніть хоча б один критерій пошуку");
                return;
            }

            var res = from i in ctx.EMPLOYEE
                      select new
                      {
                          id = i.ID,
                          name = i.NAME_E,
                          mail = i.EMAIL1.ADRESS,
                          department = i.DEPARTMENT1.D_NAME,
                          cathedra = i.CATHEDRA1.C_NAME,
                          rating = i.RATING,
                          degree = i.DEGREE1.DEGREELIST.D_NAME,
                          year = i.DEGREE1.YEAR_GOT
                      };


            if (Name != String.Empty)
            {
                res = res.Where(x => x.name.StartsWith(Name)).Select(x => x);
            }

            if (Department != String.Empty)
            {
                res = res.Where(x => x.department.StartsWith(Department)).Select(x => x);
            }

            if (Cathedra != String.Empty)
            {
                res = res.Where(x => x.cathedra.StartsWith(Cathedra)).Select(x => x);
            }

            if (Email != String.Empty)
            {
                res = res.Where(x => x.mail.StartsWith(Email)).Select(x => x);
            }

            if (Rating != String.Empty)
            {
                res = res.Where(x => x.rating.ToString().StartsWith(Rating)).Select(x => x);
            }

            if (Degree!=String.Empty)
            {
                res = res.Where(x => x.degree.StartsWith(Degree)).Select(x => x);
            }

            if (Year!=String.Empty)
            {
                res = res.Where(x => x.year.ToString().StartsWith(Year)).Select(x => x);
            }

            var bind_res = res.ToList();
            dgv.DataSource = bind_res;
        }
    }
}
