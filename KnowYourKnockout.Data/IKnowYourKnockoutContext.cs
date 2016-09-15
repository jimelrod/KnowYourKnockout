using KnowYourKnockout.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowYourKnockout.Data
{
    public interface IKnowYourKnockoutContext
    {
        DbSet<User> User { get; set; }
        DbSet<FriendRequest> FriendRequest { get; set; }
        DbSet<Question> Question { get; set; }
        DbSet<Tag> Tag { get; set; }
        DbSet<QuestionTag> QuestionTag { get; set; }
        DbSet<Error> Error { get; set; }

        int SaveChanges();
        int SaveChanges(bool acceptChanges);
    }
}
