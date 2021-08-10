using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            while (!GPIOHelper.ReadDigital(PR_GPIO))
            {
                if (runTime.Elapsed.TotalSeconds >= TIMEOUT)
                {
                    LogCenter.Instance.LogError("408 | Calibration ran into a timeout");
                    return false;
                }
            }

            //Read the stripes and calculate the distance between them
            runTime.Restart();
            timeBetweenStripes.Restart();
            while (runTime.Elapsed.TotalSeconds <= CALIBRATIONTIME)
            {
                //If another stripe got read
                if (GPIOHelper.ReadDigital(PR_GPIO))
                {
                    distances.Add((timeBetweenStripes.Elapsed.TotalSeconds.ToFixed(3) * (KPH / 3.6)).ToFixed(3));
                    timeBetweenStripes.Restart();
                    hits++;
                }
            }

            //Calculate how many stripes there are
            List<double> s = new List<double>();
            int k = 0;
            for (int i = 0; i < distances.Count; i++)
            {
                if (s.Count > 0 && s[k] == distances[i])
                {
                    if (k++ == 3)
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

        #region load / save

        public void Load()
        {
            try
            {
                string serialized = File.ReadAllText($"{Program.DIRECTORY}/velcalibration.json");
                VelocityCalibrationJSON obj = JsonConvert.DeserializeObject<VelocityCalibrationJSON>(serialized);
                IsCalibrated = obj.IsCalibrated;
                Distance = obj.Distance;
            }
            catch (Exception ex)
            {
                LogCenter.Instance.LogError(ex);
            }
        }

        public void Save()
        {
            VelocityCalibrationJSON obj = new VelocityCalibrationJSON();
            obj.Distance = Distance;
            obj.IsCalibrated = IsCalibrated;

            try
            {
                string serialized = JsonConvert.SerializeObject(obj);
                File.WriteAllText($"{Program.DIRECTORY}/velcalibration.json", serialized);
            }
            catch (Exception ex)
            {
                LogCenter.Instance.LogError(ex);
            }
        }

        #endregion

    }

    #region JSON classes

    public class VelocityCalibrationJSON
    {
        [JsonProperty("isCalibrated")]
        public bool IsCalibrated { get; set; }

        [JsonProperty("distance")]
        public List<double> Distance { get; set; }
    }

    #endregion

}
