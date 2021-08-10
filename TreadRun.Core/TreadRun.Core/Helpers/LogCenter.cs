using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreadRun.Core.Helpers
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
        public static LogCenter Instance { get; private set; } = null;

        public LogCenter()
        {
            Instance = Instance ?? this;
        }

        #region static methods

        public static void Initialize()
        {
            Instance = new LogCenter();
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
