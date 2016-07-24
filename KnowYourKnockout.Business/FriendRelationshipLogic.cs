using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;

namespace KnowYourKnockout.Business
{
    public class FriendRelationshipLogic
    {
        private KnowYourKnockoutDataApi _dataApi;

        internal FriendRelationshipLogic()
        {
            _dataApi = new KnowYourKnockoutDataApi();
        }

        internal FriendRelationshipLogic(string connectionString)
        {
            _dataApi = new KnowYourKnockoutDataApi(connectionString);
        }

        internal FriendRelationshipLogic(DbConnection connection)
        {
            _dataApi = new KnowYourKnockoutDataApi(connection);
        }

        public List<User> GetFriends(Guid id)
        {
            var leftSide = _dataApi.FriendRelationships.Get(r => r.User1Id == id).Select(u => u.User2);
            var rightSide = _dataApi.FriendRelationships.Get(r => r.User2Id == id).Select(u => u.User1);

            var friends = new List<User>(leftSide);
            friends.AddRange(rightSide);

            return friends;
        }
    }
}
