using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnuDbWithEf
{
    class AlterEmployee : Employee
    {
        public string Id { get; set; }
        private DataGridView dgv;
        private EmployeeEf.KNUDBEntities ctx;

        public AlterEmployee(TextBox name,
                             TextBox depart,
                             TextBox cathedra,
                             TextBox email,
                             TextBox degree,
                             TextBox rating,
                             TextBox year,

                             string ID,
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
            Id = ID;

            this.dgv = dgv;
            this.ctx = ctx;
        }

        public AlterEmployee(string ID, EmployeeEf.KNUDBEntities ctx)
        {
            Id = ID;
            this.ctx = ctx;
        }

        public void ChangePhoto(PictureBox pb)
        {
            MemoryStream stream = new MemoryStream();
            pb.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            var emp = (from i in ctx.EMPLOYEE
                      where i.ID.ToString() == Id
                      select i).Single();
            emp.PHOTO1.IMAGEDATA = pic;
            //Увага! зміни фото не зберігаються в цій функції
            //для їх збереження треба натиснути "змінити працівника"
            //див функцію Сhange()
            
        }

        public void Change(ref bool success)
        {
            success = false; 
            var curEmp = (from i in ctx.EMPLOYEE
                          where i.ID.ToString() == Id
                          select i).Single();

            //перевірили чи є змни
            if (Name ==  curEmp.NAME_E &&
               Department == curEmp.DEPARTMENT1.D_NAME &&
               Cathedra == curEmp.CATHEDRA1.C_NAME &&
               Email == curEmp.EMAIL1.ADRESS &&
               Degree == curEmp.DEGREE1.DEGREELIST.D_NAME &&
               Rating == curEmp.RATING.ToString() &&
               Year == curEmp.DEGREE1.YEAR_GOT.ToString()
               )
            {
                MessageBox.Show("Здається, що Вас цей викладач повністю влаштовує, адже Ви не внесли ніяких змін в його профіль :)");
                return;
            }

            if(Name==String.Empty ||
                Department==String.Empty ||
                Cathedra==String.Empty ||
                Email==String.Empty ||
                Degree==String.Empty ||
                Rating==String.Empty ||
                Year==String.Empty
               )
            {
                MessageBox.Show("Заповність всі поля");
            }

            byte temp;
            if (Byte.Parse(Rating) < ConstantValues.RatingLowerLimit || Byte.Parse(Rating) > ConstantValues.RatingUpperLimit || !Byte.TryParse(Rating, out temp))
            {
                MessageBox.Show("Недопустиме значення рейтингу");
                return;
            }
            else
            {
                curEmp.RATING = Convert.ToByte(Rating);
            }

            int temp2;
            if (Int32.Parse(Year) < ConstantValues.YearLowerLimit || Int32.Parse(Year) > ConstantValues.YearUpperLimit || !Int32.TryParse(Year, out temp2))
            {
                MessageBox.Show("Недопустиме значення року отримання звання");
                return;
            }
            else
            {
                curEmp.DEGREE1.YEAR_GOT = Convert.ToInt32(Year);
            }

            //пробігтися по всім параметрам і додати зміни в БД
            if (curEmp.DEPARTMENT1.D_NAME!=Department)
            {
                var numOfSuchDep = (from i in ctx.DEPARTMENT
                                    where i.D_NAME == Department
                                    select i).Count();
                if(numOfSuchDep<1)
                {
                    MessageBox.Show("Даного факультету не існує");
                    return;
                }
                curEmp.DEPARTMENT = (from i in ctx.DEPARTMENT
                                     where i.D_NAME == Department
                                     select i.ID).Single();
            }

            if(curEmp.CATHEDRA1.C_NAME!=Cathedra)
            {
                var numOfSuchCathedra = (from i in ctx.CATHEDRA
                                         where i.C_NAME == Cathedra &&
                                         i.DEPARTMENT.D_NAME == Department
                                         select i).Count();
                if(numOfSuchCathedra<1)
                {
                    MessageBox.Show("Даної кафедри не існує");
                    return;
                }
                curEmp.CATHEDRA = (from i in ctx.CATHEDRA
                                   where i.C_NAME == Cathedra &&
                                   i.DEPARTMENT.D_NAME == Department
                                   select i.ID).Single();
            }

            if(curEmp.EMAIL1.ADRESS != Email)
            {
                var numOfSuchEmail = (from i in ctx.EMAIL
                                      where i.ADRESS == Email
                                      select i).Count();
                if(numOfSuchEmail>0)
                {
                    MessageBox.Show("Такий EMAIL вже існує. Введіть унікальну адресу");
                    return;
                }
                curEmp.EMAIL1.ADRESS = Email; 
            }

            if(curEmp.DEGREE1.DEGREELIST.D_NAME!=Degree)
            {
                var numOfSuchDegree = (from i in ctx.DEGREELIST
                                       where i.D_NAME == Degree
                                       select i).Count();
                if(numOfSuchDegree<1)
                {
                    MessageBox.Show("Такого звання не існує!");
                    return;
                }
                curEmp.DEGREE1.NAME_D = (from i in ctx.DEGREELIST
                                         where i.D_NAME == Degree
                                         select i.ID).Single();
            }

            if(curEmp.NAME_E!=Name)
            {
                curEmp.NAME_E = Name;
            }

            success = true;
            MessageBox.Show("Вітання! Зміни успішні!");
        }

    }
}
