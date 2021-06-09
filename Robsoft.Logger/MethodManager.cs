using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Robsoft.Logger
{
    class MethodManager:IMethodManager
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name +" ";
        }
         
        public string GetCurrentMethod(Exception ex)
        {
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;
            return methodName;
        }

        public string GetCurrentMethod(IOException ex)
        {
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;
            return methodName;
        }

        public string GetCurrentMethod(FileNotFoundException ex)
        {
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;
            return methodName;
        }

        public string GetCurrentMethod(DirectoryNotFoundException ex)
        {
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;
            return methodName;
        }

        public string GetCurrentMethod(DllNotFoundException ex)
        {
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;
            return methodName;
        }

    }
}
