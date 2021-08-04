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

        private void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine(string.Format("[{0} at {1}]: {2}", logLevel, DateTime.Now, message));
        }

        #endregion

        #region public methods

        public void LogInfo(string message)
        {
            Log(LogLevel.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public void LogError(string message)
        {
            Log(LogLevel.Error, message);
        }

        public void LogError(Exception exception)
        {
            Log(LogLevel.Error, exception.StackTrace);
        }

        public void LogFatal(string message)
        {
            Log(LogLevel.Fatal, message);
        }
        public void LogFatalWarning(string message)
        {
            Log(LogLevel.FatalWarning, message);
        }
        public void LogFatalError(string message)
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
