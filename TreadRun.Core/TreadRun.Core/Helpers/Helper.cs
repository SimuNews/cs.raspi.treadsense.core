using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadRun.Core.Extensions
{
    public static class Helper
    {
        public static T StringToEnum<T>(string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }
    }
}
