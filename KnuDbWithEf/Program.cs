using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnuDbWithEf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AuthorisationForm authorisationForm = new AuthorisationForm();
            //we authorize either administrator or user 
            if (authorisationForm.ShowDialog() == DialogResult.OK)
            {
                if (authorisationForm.Status == ConstantValues.UserStatus.Admin)
                    Application.Run(new MainForm());
                else Application.Run(new MainFormUser());
            }
        }
    }
}
