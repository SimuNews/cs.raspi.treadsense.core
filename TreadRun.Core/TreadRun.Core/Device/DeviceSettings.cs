using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadRun.Core.Device
{
    public enum DeviceType
    {
        Default,
        Pro,
        Plus,
        Beta,
        Develop
    }

    class DeviceSettings
    {

        private readonly string DeviceName;
        private readonly DeviceType DeviceType;
        private readonly bool IsInitialized;

        public DeviceSettings(string deviceName, DeviceType deviceType, bool isInitialized)
        {
            DeviceName = deviceName;
            DeviceType = deviceType;
            IsInitialized = isInitialized;
        }

        #region overrides

        public override string ToString()
        {
            return string.Format("DeviceName: {0}, DeviceType: {1}, IsInitialized: {2}", DeviceName, DeviceType, IsInitialized);
        }

        #endregion
    }
}
