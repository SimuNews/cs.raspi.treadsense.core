using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadSense.Helpers
{
    enum LogLevel
    {
        Info,
        Warning,
        Error,
        Fatal,
        FatalWarning,
        FatalError
    }

    public class LogCenter
    {
        #region threadsafe singleton

        private static volatile LogCenter _instance;
        private static readonly object SyncRoot = new object();

        public static LogCenter Instance
        {
            [DebuggerStepThrough]
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new LogCenter();
                    }
                }

                return _instance;
            }
        }

        #endregion

        #region private methods

        private void Log(LogLevel logLevel, object message)
        {
            Console.WriteLine(string.Format("[{0} at {1}]: {2}", logLevel, DateTime.Now.TimeOfDay, message));
        }

        #endregion

        #region public methods

        public void LogInfo(object message)
        {
            Log(LogLevel.Info, message);
        }

        public void LogWarning(object message)
        {
            Log(LogLevel.Warning, message);
        }

        public void LogError(object message)
        {
            Log(LogLevel.Error, message);
        }

        public void LogError(Exception exception)
        {
            Log(LogLevel.Error, exception.StackTrace);
        }

        public void LogFatal(object message)
        {
            Log(LogLevel.Fatal, message);
        }
        public void LogFatalWarning(object message)
        {
            Log(LogLevel.FatalWarning, message);
        }
        public void LogFatalError(object message)
        {
            Log(LogLevel.FatalError, message);
        }
        public void LogFatalError(Exception exception)
        {
            Log(LogLevel.FatalError, exception.StackTrace);
        }

        #endregion
    }
}
