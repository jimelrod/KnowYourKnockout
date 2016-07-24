using System;

namespace KnowYourKnockout.Data.Models
{
    public class FriendRequest
    {
        public Guid Id { get; set; }
        public Guid RequesterId { get; set; }
        public Guid RequesteeId { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsActive { get; set; }
        public DateTime SentOn { get; set; }
        public DateTime? RespondedOn { get; set; }

        public virtual User Requester { get; set; }
        public virtual User Requestee { get; set; }
    }
}
