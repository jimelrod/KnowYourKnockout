using KnowYourKnockout.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowYourKnockout.Data
{
    public interface IKnowYourKnockoutContext
    {
         DbSet<User> Users { get; set; }
         DbSet<FriendRequest> FriendRequests { get; set; }
         DbSet<Tag> Tags { get; set; }
         DbSet<Question> Questions { get; set; }
    }
}
