using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KymetaCodingTest.Helpers
{
    public class Helper
    {
        public Helper()
        {

        }

        /// <summary>
        /// Convert string to number
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return -1 if the conversion failed. Otherwise return an integer</returns>
        public int ConvertStringToNumber(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                if (Int32.TryParse(str, out int newVal))
                {
                    return newVal;
                }
            }
            return -1;
        }

        /// <summary>
        /// Check if the string contains only numeric values
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsNumeric(string str)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(str);
        }
    }
}
