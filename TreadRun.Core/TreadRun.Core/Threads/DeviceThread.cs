using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadRun.Core.Calibration;
using TreadRun.Core.Helpers;
using TreadRun.Core.Services;
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

            if(!CalibrationService.Instance.VelocityCalibration.IsCalibrated)
            {
                if(CalibrationService.Instance.VelocityCalibration.Calibrate())
                    LogCenter.Instance.LogInfo("Calibration successful!");
            }

            while (true)
            {
                await Task.Delay(1000);
            }
        }
    }
}
