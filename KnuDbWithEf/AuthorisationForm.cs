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
    public partial class AuthorisationForm : Form
    {
        private KNUDBEntities ctx;
        public ConstantValues.UserStatus Status { get; set; } = ConstantValues.UserStatus.User;
        public AuthorisationForm()
        {
            InitializeComponent();
            ctx = new KNUDBEntities();
            ctx.USERS.Load();
            ctx.STATUS.Load();
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Authorisation authorisation = new Authorisation(ctx);
                Status = authorisation.Login(loginTextBox, passwordTextBox);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void newUserBtn_Click(object sender, EventArgs e)
        {
            registerLoginTextBox.Enabled = true;
            registerNameTextBox.Enabled = true;
            registerConfirmPasswordTextBox.Enabled = true;
            registerPasswordTextBox.Enabled = true;
            registerBtn.Enabled = true;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration(ctx);
            try
            {
                registration.Register(registerLoginTextBox.Text,
                                                  registerPasswordTextBox.Text,
                                                  registerConfirmPasswordTextBox.Text,
                                                  registerNameTextBox.Text
                                                    );
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }

            registerLoginTextBox.Text = String.Empty;
            registerNameTextBox.Text = String.Empty;
            registerConfirmPasswordTextBox.Text = String.Empty;
            registerPasswordTextBox.Text = String.Empty;
        }

        private void AuthorisationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctx.Dispose();
        }
    }
}
