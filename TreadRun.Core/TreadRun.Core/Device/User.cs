using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadRun.Core.Device
{
    class User
    {
        public static User Instance { get; private set; }

        public DeviceSettings DeviceSettings { get; }

        public User(DeviceSettings device)
        {
            DeviceSettings = device;
        }

        public static void Initialize(DeviceSettings device)
        {
            Instance = Instance ?? new User(device);
        }
    }
}
