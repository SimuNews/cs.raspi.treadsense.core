using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadSense.Calibration
{
    interface ICalibration
    {
        bool IsCalibrated { get; }
        bool Calibrate();

        void Load();
        void Save();
    }
}
