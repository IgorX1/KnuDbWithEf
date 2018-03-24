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
            ctx.DEPARTMENT.Load();
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
            var cath_query = (from i in ctx.CATHEDRA
                              select new
                              {
                                  name = i.C_NAME,
                                  dep = i.DEPARTMENT.D_NAME
                              }).ToList();
            eMPLOYEEBindingSource.DataSource = query;
            cATHEDRABindingSource.DataSource = cath_query;
            dEPARTMENTBindingSource.DataSource = ctx.DEPARTMENT.Local.ToBindingList();
            dEGREELISTBindingSource.DataSource = ctx.DEGREELIST.Local.ToBindingList();
            mainDataGridView.DataSource = eMPLOYEEBindingSource;
            dataGridView3.DataSource = cATHEDRABindingSource;

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
            ReleasePropertiesOfControls();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            EmployeeAddingForm addEmployeeForm = new EmployeeAddingForm(mainDataGridView, ctx);
            addEmployeeForm.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
        }

        private void dEPARTMENTBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (statsTab.SelectedTab != empTab)
            {
                MessageBox.Show("Видаляйте працівника лише при активній вкладці \"Працівники\"");
                return;
            }

            int id = (int)mainDataGridView[0, mainDataGridView.CurrentRow.Index].Value;
            EMPLOYEE eMPLOYEE = (from i in ctx.EMPLOYEE
                                 where i.ID == id
                                 select i).First();

            if (MessageBox.Show("Ви впевнені?", "Attention!", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                ctx.PHOTO.Remove(eMPLOYEE.PHOTO1);
                ctx.DEGREE.Remove(eMPLOYEE.DEGREE1);
                ctx.EMAIL.Remove(eMPLOYEE.EMAIL1);
                ctx.EMPLOYEE.Remove(eMPLOYEE);
                eMPLOYEEBindingSource.RemoveCurrent();
                ctx.SaveChanges();
                ReleasePropertiesOfControls();
                MessageBox.Show("Вітання! Видалення успішне!");
                mainDataGridView.DataSource = ctx.EMPLOYEE.Local.ToList();
            }
            
        }

        private void ReleasePropertiesOfControls()
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctx.Dispose();
        }
    }
}
