using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadRun.Core.Calibration;

namespace TreadRun.Core.Services
{
    class CalibrationService
    {
		#region threadsafe singleton

		private static volatile CalibrationService _instance;
		private static readonly object SyncRoot = new object();

		public static CalibrationService Instance
		{
			[DebuggerStepThrough]
			get
			{
				if (_instance == null)
				{
					lock (SyncRoot)
					{
						if (_instance == null)
							_instance = new CalibrationService();
					}
				}

				return _instance;
			}
		}

        #endregion

        #region public properties

        // Register calibration models
        public VelocityCalibration VelocityCalibration { get; set; }

        #endregion

        #region public methods

        public void Initialize()
		{
			CreateNewServiceInstances();
		}

		public void CreateNewServiceInstances()
		{
			VelocityCalibration = new VelocityCalibration();
		}

        #endregion
    }
}
