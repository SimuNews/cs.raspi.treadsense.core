using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadRun.Core.Helpers;

namespace TreadRun.Core.Calibration
{
    class VelocityCalibration : ICalibration
    {
        //Speed used to calibrate the device (kph)
        private const int KPH = 5;
        //How long should the calibration wait for the first stripe (sec)
        private const int TIMEOUT = 5;
        //How long should the calibration run (sec)
        private const int CALIBRATIONTIME = 15;

        //Photresistor GPIO pin
        private const int PR_GPIO = 17;

        public List<double> Distance { get; private set; }

        public bool IsCalibrated { get; private set; }

        /// <summary>
        /// Starts the calibartion of the treadmill and the device
        /// Routine:
        ///     User starts treadmill to 5 kph
        ///     Wait for the first photoResistor input
        ///     Count time between the two inputs and store the distance
        ///     Run 60 seconds then the <double>AverageDeltaTime</double> should be accurate enough
        /// </summary>
        /// <returns>True, if the calibration was a success</returns>
        public bool Calibrate()
        {
            LogCenter.Instance.LogInfo("Start calibrating");

            //vars
            int hits = 0;
            List<double> distances = new List<double>();

            //start timer
            Stopwatch runTime = new Stopwatch();
            Stopwatch timeBetweenStripes = new Stopwatch();

            runTime.Start();
            while (true/* !Read white stripe */)
            {
                if(runTime.Elapsed.TotalSeconds >= TIMEOUT)
                {
                    LogCenter.Instance.LogError("408 | Calibration ran into a timeout");
                    //Send server a TIMEOUT message (408 Request Timeout)
                    return false;
                }
            }


            List<int> ms = new List<int>()
            {
                100, 120, 110, 106, 280, 10, 22,12,
            };
            int j = 1;
            int x = 100;




            //Read the stripes and calculate the distance between them
            runTime.Restart();
            timeBetweenStripes.Restart();
            while(runTime.Elapsed.TotalSeconds <= CALIBRATIONTIME)
            {
                //If another stripe got read
                if (timeBetweenStripes.ElapsedMilliseconds >= x)
                {
                    distances.Add((timeBetweenStripes.Elapsed.TotalSeconds.ToFixed(3) * (KPH / 3.6)).ToFixed(3));

                    if (j >= ms.Count)
                        j = 0;

                    x = ms[j++];

                    timeBetweenStripes.Restart();
                    hits++;
                }
            }

            //Calculate how many stripes there are
            List<double> s = new List<double>();
            int k = 0;
            for (int i = 0; i < distances.Count; i++)
            {
                if(s.Count > 0 && s[k] == distances[i])
                {
                    if(k++ == 3)
                    {
                        break;
                    }
                }
                s.Add(distances[i]);
            }
            s.RemoveRange(s.Count - 4, 3);

            Distance = s;
            IsCalibrated = true;

            return true;
        }

        public void Load()
        {

        }

        public void Save()
        {

        }

    }
}
