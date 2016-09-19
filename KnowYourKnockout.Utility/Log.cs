using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace KnowYourKnockout.Utility
{
    public class Log
    {
        private KnowYourKnockoutContext _context;

        public Log(KnowYourKnockoutContext context)
        {
            _context = context;
        }

        public void Insert(Exception ex)
        {
            Insert(ex, string.Empty);
        }

        public void Insert(Exception ex, string className)
        {
            Insert(ex, className, string.Empty);
        }

        public void Insert(Exception ex, string className, string methodName)
        {
            var message = ex.Message;

            while (ex.InnerException != null)
            {
                message += string.Format("\n\nInner Exception:\n{0}", ex.InnerException.Message);
                ex = ex.InnerException;
            }

            try
            {
                _context.Error.Add(new Error
                {
                    Message = message,
                    Class = className,
                    Method = methodName
                });

                _context.SaveChanges();

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
            catch(Exception exception)
            {
                var rawError = GenerateRawErrorString(exception, message, className, methodName);

                WriteToErrorFile(rawError);
            }            
        }

        private string GenerateRawErrorString(Exception ex, string message, string className, string methodName)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Error logging error to database. Not a whole lot we can do now...");
            sb.AppendLine(ex.Message);
            sb.AppendLine("Initial Error:");
            sb.AppendLine(string.Format("Message - {0}", message));

            if (!string.IsNullOrEmpty(className))
            {
                sb.AppendLine(string.Format("Class - {0}", className));
            }
            if (!string.IsNullOrEmpty(methodName))
            {
                sb.AppendLine(string.Format("Method - {0}", methodName));
            }

            sb.AppendLine("\n==========================================");

            return sb.ToString();
        }

        private void WriteToErrorFile(string s)
        {
            var dateString = DateTime.Now.ToString("yyyyMMdd-HHmmss-ffff");
            var fileName = string.Format("c:\\projects\\logs\\kyk\\{0}.txt", dateString);

            try
            {
                File.WriteAllText(fileName, s);
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
        }
    }
}
