using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadRun.Core.Calibration
{
    interface ICalibration
    {
        bool IsCalibrated { get; }
        bool Calibrate();
    }
}
