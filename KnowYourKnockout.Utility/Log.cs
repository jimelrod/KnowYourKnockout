using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using System;

namespace KnowYourKnockout.Utility
{
    public class Log
    {
        private KnowYourKnockoutContext _context;

        public Log(KnowYourKnockoutContext context)
        {
            _context = context;
        }

        public void Insert(string message)
        {
            Insert(message, string.Empty);
        }

        public void Insert(string message, string className)
        {
            Insert(message, className, string.Empty);
        }

        public void Insert(string message, string className, string methodName)
        {
            try
            {
                _context.Error.Add(new Error
                {
                    Message = message,
                    Class = className,
                    Method = methodName
                });

                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error logging error to database. Not a whole lot we can do now...");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Initial Error:");
                Console.WriteLine(string.Format("Message - {0}", message));

                if (!string.IsNullOrEmpty(className))
                {
                    Console.WriteLine(string.Format("Class - {0}", className));
                }
                if (!string.IsNullOrEmpty(methodName))
                {
                    Console.WriteLine(string.Format("Method - {0}", methodName));
                }
            }            
        }
    }
}
