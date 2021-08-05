using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Unosquare.RaspberryIO;
//using Unosquare.WiringPi;

namespace TreadRun.Core.Threads
{
    class DeviceThread
    {
        public static async Task StartAsync()
        {
            //Init RaspberryIO
            //Pi.Init<BootstrapWiringPi>();

            while (true)
            {
                

                await Task.Delay(1);
            }
        }
    }
}
