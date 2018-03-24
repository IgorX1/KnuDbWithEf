using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnuDbWithEf
{
    public partial class EmployeeAddingForm : Form
    {
        DataGridView dgv;
        EmployeeEf.KNUDBEntities ctx;
        public EmployeeAddingForm(DataGridView dgv, EmployeeEf.KNUDBEntities ctx)
        {
            InitializeComponent();
            this.dgv = dgv;
            this.ctx = ctx;
        }

        private void cancelNewBtn_Click(object sender, EventArgs e)
        {
            EmployeeAdding employeeAdding = new EmployeeAdding(ctx);
            employeeAdding.CancelButtonPressed(nameTextBox2,
                                               departmentComboBox2,
                                               cathedraComboBox2,
                                               emailTextBox2,
                                               degreeComboBox2,
                                               yearTextBox2,
                                               ratingTextBox2,
                                               employeePhotoPB
                                                );
        }

        private void photoNewBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                employeePhotoPB.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void saveNewBtn_Click(object sender, EventArgs e)
        {
            EmployeeAdding employeeAdding = new EmployeeAdding(ctx, this);
            employeeAdding.AddEmployeeButtonPressed(nameTextBox2,
                                               departmentComboBox2,
                                               cathedraComboBox2,
                                               emailTextBox2,
                                               degreeComboBox2,
                                               yearTextBox2,
                                               ratingTextBox2,
                                               employeePhotoPB,
                                               dgv
                                               );
            dgv.DataSource = ctx.EMPLOYEE.Local.ToList();
        }

        private void EmployeeAddingForm_Load(object sender, EventArgs e)
        {
            dEPARTMENTBindingSource.DataSource = ctx.DEPARTMENT.Local.ToList();
            cATHEDRABindingSource.DataSource = ctx.CATHEDRA.Local.ToList();
            dEGREELISTBindingSource.DataSource = ctx.DEGREELIST.Local.ToList();
        }
    }
}
