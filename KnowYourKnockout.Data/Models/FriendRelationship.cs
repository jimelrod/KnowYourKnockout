using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    [Table("FriendRelationship")]
    public class FriendRelationship
    {
        [Key]
        [Column(Order = 1)]
        public Guid User1Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public Guid User2Id { get; set; }

        [JsonIgnore]
        public virtual User User1 { get; set; }
        [JsonIgnore]
        public virtual User User2 { get; set; }
    }
}
