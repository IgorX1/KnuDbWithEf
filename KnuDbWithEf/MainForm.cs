using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using EmployeeEf;

namespace KnuDbWithEf
{
    public partial class MainForm : Form
    {
        private KNUDBEntities ctx;
        private string indexOfEmployeeVisualization;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //load the DB info to the context
            ctx = new KNUDBEntities();
            ctx.CATHEDRA.Load();
            ctx.DEGREE.Load();
            ctx.DEGREELIST.Load();
            ctx.EMAIL.Load();
            ctx.EMPLOYEE.Load();
            ctx.PHOTO.Load();
            ctx.STATUS.Load();
            ctx.USERS.Load();

            //fill the main gridview
            var query = (from i in ctx.EMPLOYEE
                        select new
                        {
                            id = i.ID,
                            name = i.NAME_E,
                            mail = i.EMAIL1.ADRESS,
                            department = i.DEPARTMENT1.D_NAME,
                            cathedra = i.CATHEDRA1.C_NAME,
                            rating = i.RATING,
                            degree = i.DEGREE1.NAME_D,
                            year = i.DEGREE1.YEAR_GOT
                        }).ToList();
            eMPLOYEEBindingSource.DataSource = query;
            mainDataGridView.DataSource = eMPLOYEEBindingSource;
            //mainDataGridView.Columns[0].Visible = false;
        }

        private void mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeVisualization visualization = new EmployeeVisualization();
            try
            {
                indexOfEmployeeVisualization = mainDataGridView[0, e.RowIndex].Value.ToString();
                visualization.GetPersonalInfo(indexOfEmployeeVisualization,
                                          ctx,
                                          employeePhotoPB,
                                          nameTextBox,
                                          emailTextBox,
                                          departmentTextBox,
                                          cathedraTextBox,
                                          degreeTextBox,
                                          ratingTextBox,
                                          yearTextBox);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            delBtn.Enabled = true;
            changePhotoBtn.Enabled = true;
            alterEmployee.Enabled = true;
            finishShowBtn.Enabled = true;
        }

        private void finishShowBtn_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = String.Empty;
            emailTextBox.Text = String.Empty;
            departmentTextBox.Text = String.Empty;
            degreeTextBox.Text = String.Empty;
            cathedraTextBox.Text = String.Empty;
            ratingTextBox.Text = String.Empty;
            yearTextBox.Text = String.Empty;
            employeePhotoPB.Image = Properties.Resources.unknown_person_icon_Image_from;
            alterEmployee.Enabled = false;
            changePhotoBtn.Enabled = false;
            finishShowBtn.Enabled = false;
        }
    }
}
