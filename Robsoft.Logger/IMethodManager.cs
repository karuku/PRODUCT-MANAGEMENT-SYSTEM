using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Robsoft.Logger
{
    public interface IMethodManager
    {
        string GetCurrentMethod();
        string GetCurrentMethod(Exception ex);
        string GetCurrentMethod(IOException ex);
        string GetCurrentMethod(FileNotFoundException ex);
        string GetCurrentMethod(DirectoryNotFoundException ex);
        string GetCurrentMethod(DllNotFoundException ex);
    }
}
