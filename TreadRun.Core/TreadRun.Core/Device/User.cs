using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadSense.Services;

namespace TreadSense.Device
{
    class User
    {
		#region threadsafe singleton

		private static volatile User _instance;
		private static readonly object SyncRoot = new object();

		public static User Instance
		{
			[DebuggerStepThrough]
			get
			{
				if (_instance == null)
				{
					lock (SyncRoot)
					{
						if (_instance == null)
							_instance = new User();
					}
				}

				return _instance;
			}
		}

		#endregion

		public DeviceSettings DeviceSettings { get; private set; }

        public User() { }

		public void SetDevice(DeviceSettings device) => DeviceSettings = device;
    }
}
