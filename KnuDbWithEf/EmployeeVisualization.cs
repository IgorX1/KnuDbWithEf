using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace KnuDbWithEf
{
    class EmployeeVisualization : Employee
    {
        public void GetPersonalInfo(string index,
                                    EmployeeEf.KNUDBEntities ctx,
                                    PictureBox photo,
                                    TextBox name,
                                    TextBox email,
                                    TextBox department,
                                    TextBox cathedra,
                                    TextBox degree,
                                    TextBox rating,
                                    TextBox year)
        {
            int idx;
            try
            {
                idx = Int32.Parse(index);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Index can`t be converted to integer");
                return;
            }
            var res = (from e in ctx.EMPLOYEE
                       where e.ID == idx
                       select e).FirstOrDefault();

            name.Text = res.NAME_E;
            email.Text = res.EMAIL1.ADRESS;
            department.Text = res.DEPARTMENT1.D_NAME;
            cathedra.Text = res.CATHEDRA1.C_NAME;
            degree.Text = res.DEGREE1.DEGREELIST.D_NAME;
            rating.Text = res.RATING.ToString();
            year.Text = res.DEGREE1.YEAR_GOT.ToString();

            byte[] data = new byte[0];
            data = res.PHOTO1.IMAGEDATA;
            if (data != null)
            {
                MemoryStream stream = new MemoryStream(data);
                photo.Image = Image.FromStream(stream);
            }
            else
            {
                photo.Image = Properties.Resources.unknown_person_icon_Image_from;
            }
        }
    }
}
