using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace GetAnyWebpage.Globals
{
    class LogHelper
    {
        public static string LogName = "GetAnyWebpage";

        public static void LogError(string msg, Exception ex)
        {
            try
            {
                System.IO.File.AppendAllText(@"C:\temp\" + LogName + "Log.txt",
                    DateTime.Now + " - " + msg +
                    Environment.NewLine + "Exception:" + Environment.NewLine + ex.Message +
                    Environment.NewLine + "Stack:" + Environment.NewLine + ex.StackTrace +
                    GetInnerExceptions(ex) + Environment.NewLine +
                    "--------------------------------------------------" + Environment.NewLine + Environment.NewLine
                );
            }
            catch (Exception)
            {
                // Be silent if logging can't occur
            }
        }

        public static void LogInformation(string text)
        {
            try
            {
                System.IO.File.AppendAllText(@"C:\temp\" + LogName + "Log.txt", DateTime.Now + " - " + text + Environment.NewLine);
            }
            catch (Exception)
            {
                // Be silent if logging can't occur
            }
        }

        public static string GetInnerExceptions(Exception ex, int innerExceptionNumber = 1)
        {
            if (ex.InnerException != null)
            {
                return Environment.NewLine + "Inner Exception: " + innerExceptionNumber + Environment.NewLine +
                       ex.InnerException.Message +
                       Environment.NewLine + "Inner Exception Stack:" + Environment.NewLine + ex.InnerException.StackTrace +
                       GetInnerExceptions(ex.InnerException, innerExceptionNumber + 1);
            }
            return Environment.NewLine + "No more Inner Exceptions.";
        }

        private static string SafeString(object src)
        {
            if (src != null && !(src is DBNull))
                return src.ToString().Trim();
            return "";
        }
    }
}