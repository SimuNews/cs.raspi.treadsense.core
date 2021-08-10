using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadRun.Core.Helpers
{
    class GPIOHelper
    {
        private static Dictionary<int, int> gpios = new Dictionary<int, int>();

        public static void SetAsOutput(int gpioPin)
        {

        }

        public static void SetAsInput(int gpioPin)
        {

        }

        public static bool ReadDigital(int gpioPin)
        {
            return false;
        }
    }
}
