using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeEf;

namespace KnuDbWithEf
{
    class DepartmentManager
    {
        KNUDBEntities ctx;

        public DepartmentManager(KNUDBEntities ctx)
        {
            this.ctx = ctx;
        }

        public void Save(TextBox NametextBox)
        {
            if (NametextBox.Text == String.Empty)
            {
                MessageBox.Show("Факультет без назви? Але ж такого не буває!");
                return;
            }

            int num = (from i in ctx.DEPARTMENT
                       where i.D_NAME == NametextBox.Text
                       select i).Count();
            
            if (num > 0)
            {
                MessageBox.Show("Факультет з цією назвою вже існує!");
                return;
            }

            ctx.DEPARTMENT.Add(new DEPARTMENT { D_NAME = NametextBox.Text });
            ctx.SaveChanges();
            
            MessageBox.Show("Вітання! Новий факультет створено!");
        }

        public void Delete(string name)
        {
            //noe stands for @number of employees
            int noe = (from i in ctx.EMPLOYEE
                       where i.DEPARTMENT1.D_NAME == name
                       select i).Count();
            if (noe > 0)
            {
                throw new Exception("До факультета прив'язані співробітники. Видалити неможливо!");
            }
            var dep = (from i in ctx.DEPARTMENT
                       where i.D_NAME == name
                       select i).Single();
            ctx.DEPARTMENT.Remove(dep);
            ctx.SaveChanges();
        }
    }
}
