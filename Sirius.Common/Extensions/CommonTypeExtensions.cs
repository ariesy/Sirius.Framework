using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirius.Common.Extensions
{
    public static class CommonTypeExtensions
    {
        public static int ToInt(this object obj, int defaultValue = int.MinValue)
        {
            int result = defaultValue;
            if(int.TryParse(obj.ToStringEx(true), out result))
            {
                return result;
            }

            return defaultValue;
        }

        public static string ToStringEx(this object obj, bool trim = false)
        {
            string result = string.Empty;
            if (obj == null)
            {
                return result;
            }

            result = obj.ToString();
            if (trim)
            {
                result = result.Trim();
            }

            return result;
        }
    }
}
