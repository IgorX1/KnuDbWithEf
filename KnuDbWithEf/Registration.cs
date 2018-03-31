using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeEf;

namespace KnuDbWithEf
{
    class Registration
    {
        private KNUDBEntities ctx;
        public Registration(KNUDBEntities ctx)
        {
            this.ctx = ctx;
        }
        public void Register(string login,
                             string password,
                             string confirm_password,
                             string name)
        {
            //check if all fields are filled
            if (login == String.Empty ||
                password == String.Empty ||
                confirm_password == String.Empty ||
                name == String.Empty)
            {
                throw new Exception("Заповніть всі поля!");
            }
            //check if password is equal to confirmed password
            if (password != confirm_password)
            {
                throw new Exception("Впевніться в правильності вводу пароля");
            }

            var checkIfExists = (from i in ctx.USERS
                                 where i.LOGIN == login
                                 select i).Any();

            if (checkIfExists == true)
            {
                throw new Exception("Акаунт з таким логіном вже існує. Оберіть унікальний логін.");
            }

            USERS user = new USERS()
            {
                LOGIN = login,
                PASSWORD = password,
                NAME = name,
                STATUS1 = ctx.STATUS.Where(x => x.NAME == ConstantValues.userCode).Single()
            };

            ctx.USERS.Add(user);

            try
            {
                ctx.SaveChanges();
            }
            catch (Exception except)
            {
                if (except is System.Data.Entity.Infrastructure.DbUpdateException
                    || except is System.Data.Entity.Infrastructure.DbUpdateConcurrencyException
                    || except is System.Data.Entity.Validation.DbEntityValidationException)
                {
                    throw new Exception("Проблеми під час комунікації з БД");
                }
            }

            MessageBox.Show("Вітання! Реєстрація успішна. Введіть Ваші дані в поля для авторизації.");
        }
    }
}
