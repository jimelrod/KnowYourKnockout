using System;

namespace KnowYourKnockout.Data.Models
{
    public class Error
    {
        public Error()
        {
            DateOccured = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public DateTime DateOccured { get; set; }
    }
}
