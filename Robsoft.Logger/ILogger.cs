using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robsoft.Logger
{
    public interface ILogger
    {
        void LogData(string message, string folderPath = "");
    }
}
