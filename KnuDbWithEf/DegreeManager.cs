using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeEf;

namespace KnuDbWithEf
{
    class DegreeManager
    {
        KNUDBEntities ctx;
        public DegreeManager(KNUDBEntities ctx)
        {
            this.ctx = ctx;
        }
        public void Save(TextBox NametextBox)
        {
            if (NametextBox.Text == String.Empty)
            {
                MessageBox.Show("Звання без назви? Але ж такого не буває!");
                return;
            }

            int num = (from i in ctx.DEGREELIST
                       where i.D_NAME == NametextBox.Text
                       select i).Count();
            if (num > 0)
            {
                MessageBox.Show("Звання з цією назвою вже існує!");
                return;
            }

            ctx.DEGREELIST.Add(new DEGREELIST { D_NAME = NametextBox.Text });
            ctx.SaveChanges();

            MessageBox.Show("Вітання! Нове звання створено!");
        }

        public void Delete(string name)
        {
            bool num = (from i in ctx.EMPLOYEE
                       where i.DEGREE1.DEGREELIST.D_NAME == name
                       select i).Any();
            if(num)
            {
                throw new Exception("До звання прив'язані співробітники. Видалити неможливо!");
            }

            var degree = (from i in ctx.DEGREELIST
                         where i.D_NAME == name
                         select i).Single();
            ctx.DEGREELIST.Remove(degree);
            ctx.SaveChanges();
            MessageBox.Show("Вітання! Звання видалено!");
        }
    }
}
