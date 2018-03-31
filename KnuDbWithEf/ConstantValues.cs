using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuDbWithEf
{
    public static class ConstantValues
    {
        static public int YearLowerLimit = DateTime.Today.Year - 1000;
        static public int YearUpperLimit = DateTime.Today.Year;
        static public int RatingLowerLimit = 0;
        static public int RatingUpperLimit = 100;
        public static string userCode = "USER";
        public static string adminCode = "ADMIN";

        public enum UserStatus
        {
            User, 
            Admin
        }
    }
}
