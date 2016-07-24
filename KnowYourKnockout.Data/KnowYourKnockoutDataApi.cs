using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Data.Repositories;
using System;
using System.Data.Common;

namespace KnowYourKnockout.Data
{
    public class KnowYourKnockoutDataApi
    {
        public KnowYourKnockoutDataApi()
        {
            InitializeRepositories(new KnowYourKnockoutDataContext());
        }

        public KnowYourKnockoutDataApi(string connectionString)
        {
            InitializeRepositories(new KnowYourKnockoutDataContext(connectionString));
        }

        public KnowYourKnockoutDataApi(DbConnection connection)
        {
            InitializeRepositories(new KnowYourKnockoutDataContext(connection));
        }

        public IRepository<Category, Guid> Categories { get; private set; }
        public IViewRepository<FriendRelationship> FriendRelationships { get; private set; }
        public IRepository<FriendRequest, Guid> FriendRequests { get; private set; }
        public IRepository<Question, Guid> Questions { get; private set; }
        public IRepository<User, Guid> Users { get; private set; }

        private void InitializeRepositories(KnowYourKnockoutDataContext context)
        {
            Categories = new CategoryRepository(context);
            FriendRelationships = new FriendRelationshipViewRepository(context);
            FriendRequests = new FriendRequestRepository(context);
            Questions = new QuestionRepository(context);
            Users = new UserRepository(context);
        }
    }
}
