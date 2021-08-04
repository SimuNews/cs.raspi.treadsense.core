using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadRun.Core.Extensions;
using TreadRun.Core.Device;
using TreadRun.Core.Helpers;

namespace TreadRun.Core
{
    class Program
    {
        //Entry point in the program/service
        static void Main(string[] args)
        {
            /*
             * args[0] can be:  (Which device is the user using)
             *  - TreadRun.ZeroW
             *
             * args[1] can be:  (is the User some special person? (TreadRun+ user, Beta tester, developer))
             *  - Default
             *  - Pro
             *  - Plus
             *  - Develop
             *  - Beta
             *
             *  args[2] can be: (is the TreadRun initialized?)
             *  - True
             *  - False
             */


            InitializeProgram();

            DeviceSettings device = null;
            User user = null;

            try
            {
                if (args.Length < 3)
                {
                    device = new DeviceSettings("TreadRun.ZeroW", DeviceType.Default, false);
                    LogCenter.Instance.LogInfo("Device with default parameter created");
                }
                else
                {
                    device = new DeviceSettings(args[0], Helper.StringToEnum<DeviceType>(args[1]), bool.Parse(args[2]));
                    LogCenter.Instance.LogInfo(string.Format("Device with custom parameter created\n({0})", device));
                }
            }
            catch (Exception ex)
            {
                LogCenter.Instance.LogError(ex.Message);
                Console.ReadKey();
                return;
            }



            //Initialize user
            user = new User(device);
            LogCenter.Instance.LogInfo("User initialized!");


            Console.ReadKey();
        }

        private static void InitializeProgram()
        {
            LogCenter.Initialize();
        }
    }
}
