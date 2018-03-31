using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuDbWithEf
{
    static class ConstantValues
    {
        static public int YearLowerLimit = DateTime.Today.Year - 1000;
        static public int YearUpperLimit = DateTime.Today.Year;
        static public int RatingLowerLimit = 0;
        static public int RatingUpperLimit = 100;
    }
}
