using System;

namespace KnowYourKnockout.Data.Models
{
    public class FriendRelationship
    {
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }

        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
