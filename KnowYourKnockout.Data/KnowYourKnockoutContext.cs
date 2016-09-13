using KnowYourKnockout.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowYourKnockout.Data
{
    public class KnowYourKnockoutContext : DbContext
    {
        public KnowYourKnockoutContext(DbContextOptions<KnowYourKnockoutContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<QuestionTag> QuestionTag { get; set; }
        public DbSet<Error> Error { get; set; }
    }
}
