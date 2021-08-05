using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadRun.Core.Calibration
{
    class VelocityCalibration : ICalibration
    {
        public bool IsCalibrated { get; private set; }

        public bool Calibrate()
        {
            return false;
        }
    }
}
