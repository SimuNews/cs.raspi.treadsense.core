using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadSense.Helpers
{
    public static class Helper
    {
        #region Extension methods

        public static T StringToEnum<T>(string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }

        public static double ToFixed(this double d, int afterComma)
        {
            return Math.Round(d, afterComma);
        }

        #endregion
    }
}
