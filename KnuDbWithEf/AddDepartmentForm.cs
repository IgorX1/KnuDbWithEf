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
    public partial class AddDepartmentForm : Form
    {
        DataGridView dataGrid;
        EmployeeEf.KNUDBEntities ctx;
        public AddDepartmentForm(DataGridView data, EmployeeEf.KNUDBEntities ctx)
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
            DepartmentManager departmentManager = new DepartmentManager(ctx);
            try
            {
                departmentManager.Save(NametextBox);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            dataGrid.DataSource = ctx.DEPARTMENT.Local.ToList();
        }
    }
}
