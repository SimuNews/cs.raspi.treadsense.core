using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadRun.Core.Calibration;
using TreadRun.Core.Helpers;
using TreadRun.Core.Services;

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
            else
            {
                LogCenter.Instance.LogInfo("Device already calibrated!");
            }
            
            CalibrationService.Instance.InclineCalibration.Calibrate();

            while (true)
            {
                await Task.Delay(1000);
            }
        }
    }
}
