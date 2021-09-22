using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadSense.Calibration;

namespace TreadSense.Device
{
    public enum DeviceType
    {
        Default,
        Plus,
        Beta,
        Develop
    }

    class DeviceSettings
    {
        #region readonly fields

        public readonly string DeviceName;
        public readonly DeviceType DeviceType;

        #endregion

        #region properties

        public bool IsInitialized { get; private set; }
        public bool IsCalibrated { get; private set; }
        public List<ICalibration> Calibrations { get; private set; }

        #endregion

        #region ctor

        public DeviceSettings(string deviceName, DeviceType deviceType, bool isCalibrated)
        {
            DeviceName = deviceName;
            DeviceType = deviceType;
            IsCalibrated = isCalibrated;

            Calibrations = new List<ICalibration>();
        }

        #endregion

        #region public methods

        public void RegisterCalibration(ICalibration item)
        {
            Calibrations.Add(item);
        }

        public void SetInitialized(bool isInitialized) => IsInitialized = isInitialized;

        #endregion

        #region private methods

        #endregion

        #region overrides

        public override string ToString()
        {
            return string.Format("DeviceName: {0}, DeviceType: {1}, IsInitialized: {2}", DeviceName, DeviceType, IsInitialized);
        }

        #endregion
    }
}
