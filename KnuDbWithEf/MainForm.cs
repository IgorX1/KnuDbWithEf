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
            ctx = new KNUDBEntities();
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

            
            dEPARTMENTBindingSource.DataSource = ctx.DEPARTMENT.Local.ToBindingList();
            dEGREELISTBindingSource.DataSource = ctx.DEGREELIST.Local.ToBindingList();
            mainDataGridView.DataSource = GetMainDGVBindingSource();
            dataGridView3.DataSource = GetCathedraDGVBindingSource();
            FixMainDgv();
            FixCathedraDGV();
        }

        private void FixMainDgv()
        {
            //this fynction is responsible for
            //setting parameners of dgv to have an
            //appropriate look
            mainDataGridView.Columns[1].HeaderText = "Ім'я";
            mainDataGridView.Columns[2].HeaderText = "Пошта";
            mainDataGridView.Columns[3].HeaderText = "Факультет";
            mainDataGridView.Columns[4].HeaderText = "Кафедра";
            mainDataGridView.Columns[5].HeaderText = "Бал";
            mainDataGridView.Columns[6].HeaderText = "Звання";
            mainDataGridView.Columns[7].HeaderText = "Рік";

            mainDataGridView.Columns[0].Visible = false;
            mainDataGridView.Columns[1].Width = 205;
            mainDataGridView.Columns[5].Width = 40;
            mainDataGridView.Columns[6].Width = 60;
            mainDataGridView.Columns[7].Width = 45;
        }
        private void FixMainDgvWidth()
        {
            mainDataGridView.Columns[1].Width = 205;
            mainDataGridView.Columns[5].Width = 40;
            mainDataGridView.Columns[6].Width = 60;
            mainDataGridView.Columns[7].Width = 45;
        }

        private void FixCathedraDGV()
        {
            dataGridView3.Columns[0].Width = 305;
            dataGridView3.Columns[1].Width = 305;
            dataGridView3.Columns[0].HeaderText = "Кафедра";
            dataGridView3.Columns[1].HeaderText = "Факультет";
        }

        public BindingSource GetMainDGVBindingSource()
        {
            var query = (from i in ctx.EMPLOYEE
                         select new
                         {
                             id = i.ID,
                             name = i.NAME_E,
                             mail = i.EMAIL1.ADRESS,
                             department = i.DEPARTMENT1.D_NAME,
                             cathedra = i.CATHEDRA1.C_NAME,
                             rating = i.RATING,
                             degree = i.DEGREE1.DEGREELIST.D_NAME,
                             year = i.DEGREE1.YEAR_GOT
                         }).ToList();
            eMPLOYEEBindingSource.DataSource = query;
            return eMPLOYEEBindingSource;
        }

        public BindingSource GetCathedraDGVBindingSource()
        {
            var cath_query = (from i in ctx.CATHEDRA
                              select new
                              {
                                  name = i.C_NAME,
                                  dep = i.DEPARTMENT.D_NAME
                              }).ToList();
            cATHEDRABindingSource.DataSource = cath_query;
            return cATHEDRABindingSource;
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
            catch (ArgumentOutOfRangeException) { }
               
            

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
            mainDataGridView.DataSource = GetMainDGVBindingSource();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            statsTab.SelectedTab = empTab;
            SearchEmployee searchEmployee = new SearchEmployee(searchNameTextBox,
                                                                searchDepartmentTextBox,
                                                                searchCathedraTextBox,
                                                                searchEmailTextBox,
                                                                searchDegreeTextBox,
                                                                searchRatingTextBox,
                                                                searchYearTextBox,
                                                                mainDataGridView,
                                                                ctx
                                                                    );
            searchEmployee.Search();
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
                mainDataGridView.DataSource = GetMainDGVBindingSource();
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

        private void ReleasePropertiesOfSearchControls()
        {
            searchNameTextBox.Text = String.Empty;
            searchRatingTextBox.Text = String.Empty;
            searchYearTextBox.Text = String.Empty;
            searchDegreeTextBox.Text = String.Empty;
            searchCathedraTextBox.Text = String.Empty;
            searchDepartmentTextBox.Text = String.Empty;
            searchEmailTextBox.Text = String.Empty;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctx.Dispose();
        }

        private void allEmployeesBtn_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = GetMainDGVBindingSource();
            ReleasePropertiesOfSearchControls();
        }

        private void alterEmployee_Click(object sender, EventArgs e)
        {
            int row = mainDataGridView.CurrentCell.RowIndex;
            string ID = mainDataGridView["ID", row].Value.ToString();

            AlterEmployee alterEmployee = new AlterEmployee(nameTextBox,
                                                            departmentTextBox,
                                                            cathedraTextBox,
                                                            emailTextBox,
                                                            degreeTextBox,
                                                            ratingTextBox,
                                                            yearTextBox,
                                                            indexOfEmployeeVisualization,
                                                            mainDataGridView, 
                                                            ctx);
            bool r = false ;
            alterEmployee.Change(ref r);
            if(r)
            {
                ctx.SaveChanges();
                mainDataGridView.DataSource = GetMainDGVBindingSource();
            }               
            else
            {
                var lst = ctx.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
                foreach(var entry in lst)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            break;
                    }
                }
            }
                

        }

        private void changePhotoBtn_Click(object sender, EventArgs e)
        {
            AlterEmployee alterEmployee = new AlterEmployee(indexOfEmployeeVisualization, ctx);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                employeePhotoPB.Image = Image.FromFile(ofd.FileName);
            }

            alterEmployee.ChangePhoto(employeePhotoPB);
        }

        private void bigIconPB_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.univ.kiev.ua/ua/");
        }

        private void addDepBtn_Click(object sender, EventArgs e)
        {
            AddDepartmentForm addDepartmentForm = new AddDepartmentForm(dataGridView2, ctx);
            addDepartmentForm.Show();
        }

        private void DelDepBtn_Click(object sender, EventArgs e)
        {
            string value = dataGridView2["dNAMEDataGridViewTextBoxColumn", dataGridView2.CurrentCell.RowIndex].Value.ToString();
            try
            {
                DepartmentManager departmentManager = new DepartmentManager(ctx);
                departmentManager.Delete(value);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            MessageBox.Show("Вітання! Факультет видалено!");
            dataGridView2.DataSource = ctx.DEPARTMENT.Local.ToList();
        }

        private void statsTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            if (current.Name == tabPage1.Name)
            {
                numOfEmpLabel.Text = ctx.EMPLOYEE.Count().ToString();
                numOfDepLabel.Text = ctx.DEPARTMENT.Count().ToString();
                numOfCathedraLabel.Text = ctx.CATHEDRA.Count().ToString();
                numOfDegreeLabel.Text = ctx.DEGREELIST.Count().ToString();
            }
            if(current.Name != empTab.Name)
            {
                //як показник того, що заповнені всі поля(бо імя точно введено)
                if(nameTextBox.Name!=String.Empty)
                {
                    ReleasePropertiesOfControls();
                }
            }
        }

        private void addCathedraBtn_Click(object sender, EventArgs e)
        {
            AddCathedraForm addCathedraForm = new AddCathedraForm(dataGridView3, ctx);
            addCathedraForm.Show();
        }

        private void delCathedraBtn_Click(object sender, EventArgs e)
        {
            string value_cath = dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString();
            string value_dep = dataGridView3[1, dataGridView3.CurrentCell.RowIndex].Value.ToString();
            try
            {
                CathedraManager cathedraManager = new CathedraManager(ctx);
                cathedraManager.Delete(value_cath, value_dep);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            dataGridView3.DataSource = GetCathedraDGVBindingSource();
        }

        private void AddDegreeBtn_Click(object sender, EventArgs e)
        {
            AddDegreeForm addDegreeForm = new AddDegreeForm(dataGridView5, ctx);
            addDegreeForm.Show();
        }

        private void DelDegreeBtn_Click(object sender, EventArgs e)
        {
            string value = dataGridView5.SelectedCells[0].Value.ToString();
            //string value = dataGridView5["dNAMEDataGridViewTextBoxColumn1", dataGridView5.CurrentCell.RowIndex].Value.ToString();
            try
            {
                DegreeManager degreeManager = new DegreeManager(ctx);
                degreeManager.Delete(value);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            dataGridView5.DataSource = ctx.DEGREELIST.Local.ToBindingList();
        }

        private void стандартнийВиглядToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FixMainDgvWidth();
        }
    }
}
