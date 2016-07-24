using KnowYourKnockout.Data.Models;
using System;
using System.Data.Common;
using System.Data.Entity;

namespace KnowYourKnockout.Data
{
    internal class KnowYourKnockoutDataContext : DbContext
    {
        internal KnowYourKnockoutDataContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<KnowYourKnockoutDataContext>(null);
        }

        internal KnowYourKnockoutDataContext(DbConnection connection)
            : base(connection, true)
        {
            
        }

        internal KnowYourKnockoutDataContext()
            :base(System.Configuration.ConfigurationManager.ConnectionStrings["KYK"].ConnectionString)
        {
            Database.SetInitializer<KnowYourKnockoutDataContext>(null);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<FriendRelationship> FriendRelationship { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<User> User { get; set; }
    }
}
