using KnowYourKnockout.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowYourKnockout.Data
{
    public class KnowYourKnockoutContext : DbContext
    {
        public KnowYourKnockoutContext(DbContextOptions<KnowYourKnockoutContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
