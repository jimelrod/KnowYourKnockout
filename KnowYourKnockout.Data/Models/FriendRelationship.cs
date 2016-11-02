﻿using System;

namespace KnowYourKnockout.Data.Models
{
    /// <summary>
    /// MAY NOT NEED!!!!
    /// </summary>
    public class FriendRelationship
    {
        public int User1Id { get; set; }
        public int User2Id { get; set; }

        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
