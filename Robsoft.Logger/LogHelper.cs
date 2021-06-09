using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Robsoft.Logger
{
   public static class LogHelper
   {
        //private static FileLogger logger;
        private static ILogger logger;
        private static IMethodManager methodManager;
        private static string logFolderPath = "";

        public static void SetLogFolder(string folderPath = "")
        {
            logFolderPath = folderPath;
        }

        public static IMethodManager GetMethodManager()
        {
            methodManager = new MethodManager();
            return methodManager;
        }

        public static void Log(LogLevel level, string message, string logOrigin="MethodNA", string logOriginClass="ClassNA")
        {
            string className = "=>" + logOriginClass+ "=>";
            string originMethod = className + logOrigin;
            if (string.IsNullOrWhiteSpace(logOrigin))
                originMethod = className+methodManager.GetCurrentMethod();

            switch (level)
            {
                case LogLevel.FINE:
                    logger = new FileLogger();
                    GetMethodManager();
                    logger.LogData("FINE: " + originMethod + message, logFolderPath);
                    break;
                case LogLevel.INFO:
                    logger = new FileLogger();
                    GetMethodManager();
                    logger.LogData("INFO: " + originMethod + message, logFolderPath);
                    break;
                case LogLevel.SEVERE:
                    logger = new FileLogger();
                    GetMethodManager();
                    logger.LogData("SEVERE: " + originMethod + message, logFolderPath);
                    break;
                case LogLevel.WARNING:
                    logger = new FileLogger();
                    GetMethodManager();
                    logger.LogData("WARNING: " + originMethod + message, logFolderPath);
                    break;
                default:
                    logger = new FileLogger();
                    GetMethodManager();
                    logger.LogData("INFO: " + originMethod + message, logFolderPath);
                    return;
            }
        }

        public static void GetMethod()
        {
            methodManager = new MethodManager();
            methodManager.GetCurrentMethod();
        }
    }
}
