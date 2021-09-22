using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadSense.Calibration;
using TreadSense.Helpers;
using TreadSense.Services;

namespace TreadSense.Threads
{
    class DeviceThread
    {
        public static async Task StartAsync()
        {
            LogCenter.Instance.LogInfo("Started thread...");

            // CAlibration is later a user problem
            if(!CalibrationService.Instance.VelocityCalibration.IsCalibrated)
            {
                if(CalibrationService.Instance.VelocityCalibration.Calibrate())
                    LogCenter.Instance.LogInfo("Calibration successful!");
            } 
            else
            {
                LogCenter.Instance.LogInfo("Device already calibrated!");
            }

            if (!CalibrationService.Instance.InclineCalibration.IsCalibrated)
            {
                if (CalibrationService.Instance.InclineCalibration.Calibrate())
                    LogCenter.Instance.LogInfo("Calibration successful!");
            }
            else
            {
                LogCenter.Instance.LogInfo("Device already calibrated!");
            }



            LogCenter.Instance.LogInfo("Start loop...");

            while (true)
            {
                await Task.Delay(10);
            }
        }
    }
}
