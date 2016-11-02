using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }
        public int RequesterId { get; set; }
        public int RequesteeId { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsActive { get; set; }
        public DateTime SentOn { get; set; }
        public DateTime? RespondedOn { get; set; }
        
        [ForeignKey("RequesterId")]
        public virtual User Requester { get; set; }
        [ForeignKey("RequesteeId")]
        public virtual User Requestee { get; set; }
    }
}
