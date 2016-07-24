using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowYourKnockout.Business
{
    public class KnowYourKnockoutBusinessApi
    {
        public KnowYourKnockoutBusinessApi()
        {
            UserLogic = new UserLogic();
            FriendRelationshipLogic = new FriendRelationshipLogic();
            FriendRequestLogic = new FriendRequestLogic();
        }

        public KnowYourKnockoutBusinessApi(string connectionString)
        {
            UserLogic = new UserLogic(connectionString);
            FriendRelationshipLogic = new FriendRelationshipLogic(connectionString);
            FriendRequestLogic = new FriendRequestLogic(connectionString);
        }

        public KnowYourKnockoutBusinessApi(DbConnection connection)
        {
            UserLogic = new UserLogic(connection);
            FriendRelationshipLogic = new FriendRelationshipLogic(connection);
            FriendRequestLogic = new FriendRequestLogic(connection);
        }

        public UserLogic UserLogic { get; private set; }
        public FriendRelationshipLogic FriendRelationshipLogic { get; private set; }
        public FriendRequestLogic FriendRequestLogic { get; private set; }
    }
}
