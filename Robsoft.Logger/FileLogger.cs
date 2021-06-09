using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Robsoft.Logger
{
    class FileLogger:ILogger
    {
        //private string sLogFile = AppDomain.CurrentDomain.BaseDirectory + @"\ws_data\elog.txt";
        //private string sLogFolder = AppDomain.CurrentDomain.BaseDirectory + @"\ws_data";

        private string sLogFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\RobsoftLogger\WizagReportManager\elog.txt");
        private string sLogFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\RobsoftLogger\RSA");
         
        private string getDirectory(string folderPath = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(folderPath))
                    sLogFolder = folderPath;

                if (!Directory.Exists(sLogFolder))
                {
                    Directory.CreateDirectory(sLogFolder);
                }
                return sLogFolder;
            }
            catch (IOException ee)
            {
                Console.WriteLine("checkDirectory Error: " + ee.Message);
                return "";
            }
            catch (Exception ee)
            {
                Console.WriteLine("checkDirectory Error: " + ee.Message);
                return "";
            }
        }

        private string getFile(string folderPath = "")
        {
            string sLogFile = "";
            string folder = getDirectory(folderPath);
            try
            {
                if (!string.IsNullOrWhiteSpace(folder))
                    sLogFolder = folder;

                sLogFile = Path.Combine(sLogFolder, "log.txt");

                if (!File.Exists(sLogFile))
                {
                    File.Create(sLogFile).Dispose();
                }
                return sLogFile;
            }
            catch (IOException ee)
            {
                Console.WriteLine("checkFile Error: " + ee.Message);
                return "";
            }
            catch (Exception ee)
            {
                Console.WriteLine("checkFile Error: " + ee.Message);
                return "";
            }
        }

        public void LogData(string message, string folderPath = "")
        {
            string logFile = getFile(folderPath);
            try
            { 
                lock (message)
                {
                    using (StreamWriter swLog = new StreamWriter(logFile, true))
                    {
                        swLog.Write(DateTime.Now.ToString() + "  ->  " + message);
                        swLog.WriteLine();
                        swLog.Flush();
                        swLog.Close();
                    }
                }
            }
            catch (IOException ee)
            { 
                Console.WriteLine("getLogger Error: " + ee.Message);
            }
            catch (Exception ee)
            {
                Console.WriteLine("getLogger Error: " + ee.Message);
            }
        }
    }
}
