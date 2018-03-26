using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnuDbWithEf
{
    class CathedraManager
    {
        private EmployeeEf.KNUDBEntities ctx;
        public CathedraManager(EmployeeEf.KNUDBEntities ctx)
        {
            this.ctx = ctx;
        }
        public void Save(TextBox name, string dep)
        {
            
            if (name.Text == String.Empty)
            {
                MessageBox.Show("Кафедра без назви? Але ж такого не буває!");
                return;
            }

            if (ctx.CATHEDRA.Where(x => x.C_NAME == name.Text).Count() > 0)
            {
                MessageBox.Show("Кафедра з цією назвою вже існує!");
                return;
            }

            var c = new EmployeeEf.CATHEDRA
            {
                C_NAME = name.Text,
                DEPARTMENT_ID = (ctx.DEPARTMENT.Where(x => x.D_NAME == dep).Select(x => x.ID)).Single()
            };

            ctx.CATHEDRA.Add(c);
            ctx.SaveChanges();
            MessageBox.Show("Вітання! Нову кафедру створено!");
        }

        public void Delete(string name, string dep)
        {
            if(ctx.EMPLOYEE.Where(x=>x.CATHEDRA1.C_NAME == name && x.DEPARTMENT1.D_NAME == dep).Select(x=>x).Count()>0)
            {
                throw new Exception("До кафедри прив'язані співробітники. Видалити неможливо!");
            }

            var c = ctx.CATHEDRA.Where(x => x.C_NAME == name && x.DEPARTMENT.D_NAME == dep).Select(x => x).Single();
            ctx.CATHEDRA.Remove(c);
            ctx.SaveChanges();
            MessageBox.Show("Вітання! Кафедру видалено!");
        }
    }
    
}
