using System;
using System.Collections.Generic;

namespace KnowYourKnockout.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoinedOn { get; set; }

        public virtual List<User> Friends { get; set; }
        public virtual List<Question> QuestionsAsked { get; set; }
        public virtual List<Question> QuestionsAnswered { get; set; }
        public virtual List<FriendRequest> RequestsSent { get; set; }
        public virtual List<FriendRequest> RequestsReceived { get; set; }
    }
}
