using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Data.Sql;
using System.Windows.Forms;
using EmployeeEf;

namespace KnuDbWithEf
{
    class TransformToXml
    {
        KNUDBEntities ctx;
        public TransformToXml(KNUDBEntities ctx)
        {
            this.ctx = ctx;
        }

        public void CreateEmployeeXML()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "windows-1251", "yes"));
            XmlElement xmlElement = xmlDocument.CreateElement(ctx.Database.Connection.Database);
            xmlDocument.AppendChild(xmlElement);
            XmlElement emp;
            XmlAttribute name, department, cathedra, degree, year, email;
            foreach (var i in ctx.EMPLOYEE)
            {
                emp = xmlDocument.CreateElement("Employee");

                name = xmlDocument.CreateAttribute("Name");
                department = xmlDocument.CreateAttribute("Department");
                cathedra = xmlDocument.CreateAttribute("Cathedra");
                degree = xmlDocument.CreateAttribute("Degree");
                year = xmlDocument.CreateAttribute("YearOfDegree");
                email = xmlDocument.CreateAttribute("Email");

                name.Value = i.NAME_E;
                department.Value = i.DEPARTMENT1.D_NAME;
                cathedra.Value = i.CATHEDRA1.C_NAME;
                degree.Value = i.DEGREE1.DEGREELIST.D_NAME;
                year.Value = i.DEGREE1.YEAR_GOT.ToString();
                email.Value = i.EMAIL1.ADRESS;

                emp.Attributes.Append(name);
                emp.Attributes.Append(department);
                emp.Attributes.Append(cathedra);
                emp.Attributes.Append(degree);
                emp.Attributes.Append(year);
                emp.Attributes.Append(email);

                xmlElement.AppendChild(emp);
            }
            try
            {
                xmlDocument.Save(GetFolderPath());
            }
            catch (XmlException)
            {
                MessageBox.Show("Невдалося зберегти");
                return;
            }
            MessageBox.Show("Збереженя успішне!");

        }

        private string GetFolderPath()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.Title = "Save database to XML file";
            sfd.Filter = "XML-File | *.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            else
            {
                MessageBox.Show("Шлях збереження не коректний. Збережено в стандартну папку - робочий стіл");
                return sfd.InitialDirectory;
            }
        }
    }
}
