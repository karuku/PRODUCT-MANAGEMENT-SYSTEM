using ProductManagerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProductManagerAPI.Helpers
{
    public class ApiHelper
    {

        public static bool ValidateAppUser(string credentials, out string outMessage, out string outName)
        {
            outMessage = ""; 
            try
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string userName = credentials.Substring(0, separator);
                string password = credentials.Substring(separator+1);


                if(CheckUser(userName, password, out outMessage))
                {  
                    outName = userName; 
                    return true;
                }else
                { 
                    outName = ""; 
                    return false; 
                }
            }
            catch (Exception ex)
            {
                outMessage = ex.Message;
                outName = ""; 
                return false;
            }
           
        }

        private static bool CheckUser(string userName,string pwd,out string message)
        {
            try
            {
                var encryptedPwd = pwd;

                #region prepare variables
                message = "";
                #endregion

                #region validate user
                var isValidUserRole = Repository.GetUserList().Any(u => u.userName.ToLower() == userName.ToLower() && u.userPwd == encryptedPwd);

                if (!isValidUserRole)
                {
                    message = "invalid Account, Account cannot be found!";
                    return false;
                }

                message = "Account Validated!";
                return true;
            }
            catch(Exception ex)
            {
                message = "Validation Failure "+ex.Message;
                return false;
            }
            #endregion
        }
    }
}