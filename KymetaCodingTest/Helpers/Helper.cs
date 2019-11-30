using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KymetaCodingTest.Helpers
{
    public class Helper
    {
        public Helper()
        {

        }
        public bool convertStringToNumber(string str, int newVal)
        {
            if (str.Length > 0)
            {
                if (Int32.TryParse(str, out newVal))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
