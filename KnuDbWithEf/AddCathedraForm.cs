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
    public partial class AddCathedraForm : Form
    {
        DataGridView dataGrid;
        EmployeeEf.KNUDBEntities ctx;
        public AddCathedraForm(DataGridView data, EmployeeEf.KNUDBEntities ctx)
        {
            InitializeComponent();
            dataGrid = data;
            this.ctx = ctx;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            NametextBox.Text = String.Empty;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            CathedraManager cathedraManager = new CathedraManager(ctx);
            try
            {
                cathedraManager.Save(NametextBox, comboBox1.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            MainForm mainForm = new MainForm();
            dataGrid.DataSource = mainForm.GetCathedraDGVBindingSource();
            this.Close();
        }

        private void AddCathedraForm_Load(object sender, EventArgs e)
        {
            dEPARTMENTBindingSource.DataSource = (from i in ctx.DEPARTMENT
                                                  select i.D_NAME).ToList();
        }
    }
}
