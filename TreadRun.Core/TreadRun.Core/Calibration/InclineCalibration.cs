using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadRun.Core.Helpers;
using Unosquare.RaspberryIO;

namespace TreadRun.Core.Calibration
{
    class InclineCalibration : ICalibration
    {
        public bool IsCalibrated { get; set; }

        public float YIncline { get; set; }
        public float XIncline { get; set; }

        public bool Calibrate()
        {
            try
            {
                // Get a json string from gyro.py script
                string jsonResponse = Bash.ExecuteBashCommand("python3 ../../../../gyro.py");

                var obj = JsonConvert.DeserializeObject<InclineCalibrationJSON>(jsonResponse);

                XIncline = obj.X;
                YIncline = obj.Y;

                IsCalibrated = true;

                LogCenter.Instance.LogInfo($"Incline calibrated successfully: {XIncline}, {YIncline}");

                Save();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region load / save

        public void Load()
        {
            try
            {
                string serialized = File.ReadAllText($"{Program.DIRECTORY}/inclinecalibration.json");
                InclineCalibrationJSON obj = JsonConvert.DeserializeObject<InclineCalibrationJSON>(serialized);
                IsCalibrated = obj.IsCalibrated;
                XIncline = obj.X;
                YIncline = obj.Y;
            }
            catch (Exception ex)
            {
                LogCenter.Instance.LogError("Device wasn't calibrated before. Calibrate...");
            }
        }

        public void Save()
        {
            InclineCalibrationJSON obj = new InclineCalibrationJSON();
            obj.IsCalibrated = IsCalibrated;
            obj.X = XIncline;
            obj.Y = YIncline;

            try
            {
                string serialized = JsonConvert.SerializeObject(obj);
                File.WriteAllText($"{Program.DIRECTORY}/inclinecalibration.json", serialized);
            }
            catch (Exception ex)
            {
                LogCenter.Instance.LogError(ex);
            }

        }

        #endregion
    }

    #region JSON classes

    public class InclineCalibrationJSON
    {
        [JsonProperty("IsCalibrated")]
        public bool IsCalibrated { get; set; }

        [JsonProperty("X")]
        public float X { get; set; }

        [JsonProperty("Y")]
        public float Y { get; set; }
    }

    #endregion

}