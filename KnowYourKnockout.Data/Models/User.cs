using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoinedOn { get; set; }

        //public virtual List<User> Friends { get; set; }
        //[InverseProperty("AskerId")]
        //public virtual List<Question> QuestionsAsked { get; set; }
        //[InverseProperty("ResponderId")]
        //public virtual List<Question> QuestionsAnswered { get; set; }
        //[InverseProperty("RequesterId")]
        //public virtual List<FriendRequest> RequestsSent { get; set; }
        //[InverseProperty("RequesteeId")]
        //public virtual List<FriendRequest> RequestsReceived { get; set; }
    }
}
