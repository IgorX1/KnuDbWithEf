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
    public partial class AddDegreeForm : Form
    {
        DataGridView dataGrid;
        EmployeeEf.KNUDBEntities ctx;
        public AddDegreeForm(DataGridView data, EmployeeEf.KNUDBEntities ctx)
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
            DegreeManager degreeManager = new DegreeManager(ctx);
            try
            {
                degreeManager.Save(NametextBox);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            dataGrid.DataSource = ctx.DEGREELIST.Local.ToList();
            this.Close();
        }
    }
}
