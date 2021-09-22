using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreadSense.Calibration;

namespace TreadSense.Services
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
							_instance = new CalibrationService().Initialize();
					}
				}

				return _instance;
			}
		}

        #endregion

        #region public properties

        // Register calibration models
        public VelocityCalibration VelocityCalibration { get; set; }
        public InclineCalibration InclineCalibration { get; set; }

        #endregion

        #region private methods

        private CalibrationService Initialize()
		{
			CreateNewServiceInstances();
			return this;
		}

		private void CreateNewServiceInstances()
		{
			#region initialize

            VelocityCalibration = new VelocityCalibration();
            InclineCalibration = new InclineCalibration();

			#endregion

			#region check for saved files

			VelocityCalibration.Load();
			InclineCalibration.Load();

			#endregion

		}

		#endregion
	}
}
