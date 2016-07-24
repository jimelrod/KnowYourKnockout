using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    [Table("FriendRequest")]
    public class FriendRequest
    {
        public FriendRequest()
        {
            IsAccepted = false;
            IsActive = true;
            SentOn = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid RequesterId { get; set; }
        public Guid RequesteeId { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsActive { get; set; }
        public DateTime SentOn { get; set; }
        public DateTime? RespondedOn { get; set; }

        [JsonIgnore]
        public virtual User Requester { get; set; }
        [JsonIgnore]
        public virtual User Requestee { get; set; }
    }
}
