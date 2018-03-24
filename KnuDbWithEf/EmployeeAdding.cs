using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeEf;

namespace KnuDbWithEf
{
    class EmployeeAdding:Employee
    {
        DataGridView dgv;
        EmployeeEf.KNUDBEntities ctx;

        public EmployeeAdding(EmployeeEf.KNUDBEntities ctx)
        {
            this.ctx = ctx;
        }
        public void CancelButtonPressed(TextBox name,
                                        ComboBox department,
                                        ComboBox cathedra,
                                        TextBox email,
                                        ComboBox degree,
                                        TextBox year,
                                        TextBox rating,
                                        PictureBox photo)
        {
            if (name.Text != String.Empty)
                name.Text = String.Empty;
            if (department.Text != String.Empty)
                department.Text = String.Empty;
            if (cathedra.Text != String.Empty)
                cathedra.Text = String.Empty;
            if (email.Text != String.Empty)
                email.Text = String.Empty;
            if (degree.Text != String.Empty)
                degree.Text = String.Empty;
            if (year.Text != String.Empty)
                year.Text = String.Empty;
            if (rating.Text != String.Empty)
                rating.Text = String.Empty;
            if (photo.Image != Properties.Resources.unknown_person_icon_Image_from)
                photo.Image = Properties.Resources.unknown_person_icon_Image_from;
        }

        public void AddEmployeeButtonPressed(TextBox name,
                                ComboBox department,
                                ComboBox cathedra,
                                TextBox email,
                                ComboBox degree,
                                TextBox year,
                                TextBox rating,
                                PictureBox photo,
                                DataGridView dgv)
        {
            //перш за все перевіримо чи юзер заповнив усі поля
            if (!(name.Text != String.Empty &&
               department.SelectedIndex > -1 &&
               cathedra.SelectedIndex > -1 &&
               email.Text != String.Empty &&
               degree.SelectedIndex > -1 &&
               year.Text != String.Empty &&
               rating.Text != String.Empty
                ))
            {
                MessageBox.Show("Заповніть всі поля!", "Помилка");
                return;
            }

            //заповнимо контейтер нашого працівника
            Name = name.Text;
            Department = department.GetItemText(department.SelectedItem);
            Cathedra = cathedra.GetItemText(cathedra.SelectedItem);
            Email = email.Text;
            Degree = degree.GetItemText(degree.SelectedItem);
            Year = year.Text;
            Rating = rating.Text;
            this.dgv = dgv;

            //перевіримо чи обрав юзер фотку
            CheckPhoto(photo);

            //далі перевіримо чи юзер правильно задав комбінацію факультет -- кафедра
            try
            {
                CheckDepartmentAndCathedra();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                ReleaseProperties();
                return;
            }

            //check email format
            try
            {
                CheckEmail();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                ReleaseProperties();
                return;
            }

            if (Int32.Parse(Year) > 2100 || Int32.Parse(Year) < 1900)
            {
                MessageBox.Show("Некоректна дата отримання звання");
                ReleaseProperties();
                return;
            }

            if (Int32.Parse(Rating) > 100 || Int32.Parse(Rating) < 0)
            {
                MessageBox.Show("Некоректний формат рейтингу! Вкажіть значення з проміжку [0,...,100]");
                ReleaseProperties();
                return;
            }

            //перевіримо чи рік та рейтинг -- цілі числа???!!!
            try
            {
                CheckIfYearAndRatingAreIntegers();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                ReleaseProperties();
                return;
            }

            InsertToDB();
        }

        //прервірка чи обрав юзер фотку
        private void CheckPhoto(PictureBox photo)
        {           
            MemoryStream stream = new MemoryStream();
            photo.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Photo = stream.ToArray();
        }

        private void CheckEmail()
        {
            if (!Email.Contains("@"))
                throw new Exception("Неправильний формат електронної пошти!");
        }

        //перевірка чи є така кафедра на цьому факультеті
        private void CheckDepartmentAndCathedra()
        {
            var doesExist = (from i in ctx.CATHEDRA
                         where i.C_NAME == Cathedra && i.DEPARTMENT.D_NAME == Department
                         select i).Any();
            if (!doesExist)
            {
                throw new Exception("Неправильна комбінація факультету та кафедри");
            }

        }

        private void CheckIfYearAndRatingAreIntegers()
        {
            int a, b;
            if (!(Int32.TryParse(Year, out a) && Int32.TryParse(Rating, out b)))
            {
                throw new Exception("Некоректна форма цілого числа в полі \"Рік\" чи \"Рейтинг\"");
            }
        }

        //Опустошити всі поля
        private void ReleaseProperties()
        {
            Name = Department = Email = Cathedra = Degree = Year = Rating = String.Empty;
        }

        private void InsertToDB()
        {
            try
            {
                EMPLOYEE emp = new EMPLOYEE()
                {
                    NAME_E = Name,
                    RATING = Convert.ToByte(Rating)
                };
                EMAIL eMAIL = new EMAIL()
                {
                    ADRESS = Email
                };
                emp.EMAIL1 = eMAIL;
                PHOTO pHOTO = new PHOTO()
                {
                    IMAGEDATA = Photo,
                };
                emp.PHOTO1 = pHOTO;
                emp.DEPARTMENT = (from i in ctx.DEPARTMENT
                                  where i.D_NAME == Department
                                  select i.ID).FirstOrDefault();
                emp.CATHEDRA = (from i in ctx.CATHEDRA
                                where i.C_NAME == Cathedra && i.DEPARTMENT.D_NAME == Department
                                select i.ID).FirstOrDefault();
                DEGREE dEGREE = new DEGREE()
                {
                    YEAR_GOT = Int32.Parse(Year)
                };

                dEGREE.NAME_D = (from i in ctx.DEGREELIST
                                 where i.D_NAME == Degree
                                 select i.ID).FirstOrDefault();
                emp.DEGREE1 = dEGREE;

                ctx.EMPLOYEE.Add(emp);
            }
            catch(Exception)
            {
                MessageBox.Show("Fatal error while adding new employee");
                return;
            }

            try
            {
                ctx.SaveChanges();
                MessageBox.Show("Вітання! Співробітник доданий до БД успішно");
            }
            catch (Exception)
            {
                MessageBox.Show("Can't save changes to DB");
            }
        }
    }
}
