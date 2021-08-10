using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadRun.Core.Calibration;
using TreadRun.Core.Helpers;
//using Unosquare.RaspberryIO;
//using Unosquare.RaspberryIO.Abstractions;
//using Unosquare.WiringPi;

namespace TreadRun.Core.Threads
{
    class DeviceThread
    {
        public static async Task StartAsync()
        {
            LogCenter.Instance.LogInfo("Started thread...");

            VelocityCalibration vc = new VelocityCalibration();
            vc.Calibrate();

            while (true)
            {
                await Task.Delay(1000);
            }
        }
    }
}
