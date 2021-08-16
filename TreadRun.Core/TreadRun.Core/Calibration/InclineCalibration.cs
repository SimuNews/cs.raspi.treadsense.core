using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadRun.Core.Helpers;
using Unosquare.RaspberryIO;

namespace TreadRun.Core.Calibration
{
    class InclineCalibration : ICalibration
    {
        public bool IsCalibrated { get; set; }

        public bool Calibrate()
        {
            
            foreach (var item in Pi.I2C.Devices)
            {
                LogCenter.Instance.LogInfo(item);
            }
            return false;
        }

        #region load / save

        public void Load()
        {
            
        }

        public void Save()
        {
            
        }

        #endregion
    }

    #region JSON classes

    #endregion

}
