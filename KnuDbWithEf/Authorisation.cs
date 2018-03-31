using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using EmployeeEf;

namespace KnuDbWithEf
{
    class Authorisation
    {
        private KNUDBEntities ctx;
        public Authorisation(KNUDBEntities ctx)
        {
            this.ctx = ctx;
        }
        public ConstantValues.UserStatus Login(TextBox loginTextBox, TextBox passwordTextBox)
        {
            //check if fields are not empty
            if (loginTextBox.Text == String.Empty || passwordTextBox.Text == String.Empty)
            {
                MessageBox.Show("Заповніть всі поля!");
                throw new Exception("authorisation_error");
            }

            bool doesContain = (from i in ctx.USERS
                                where i.LOGIN == loginTextBox.Text
                                && i.PASSWORD == passwordTextBox.Text
                                select i).Any();
            if(!doesContain)
            {
                MessageBox.Show("Невірні логін та пароль. Спробуйте знову");
                throw new Exception("authorisation_error");
            }

            var status = (from i in ctx.USERS
                          where i.LOGIN == loginTextBox.Text
                          && i.PASSWORD == passwordTextBox.Text
                          select i.STATUS1.NAME).Single();
            if (status.Trim() == ConstantValues.adminCode)
                return ConstantValues.UserStatus.Admin;
            else if (status.Trim() == ConstantValues.userCode)
                return ConstantValues.UserStatus.User;
            else throw new Exception("authorisation_error");
        }
    }
}
