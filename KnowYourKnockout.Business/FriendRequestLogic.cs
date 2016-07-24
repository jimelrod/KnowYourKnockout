using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace KnowYourKnockout.Business
{
    public class FriendRequestLogic
    {
        #region FIELDS

        private KnowYourKnockoutDataApi _dataApi;

        #endregion

        #region CONSTRUCTORS

        internal FriendRequestLogic()
        {
            _dataApi = new KnowYourKnockoutDataApi();
        }

        internal FriendRequestLogic(string connectionString)
        {
            _dataApi = new KnowYourKnockoutDataApi(connectionString);
        }

        internal FriendRequestLogic(DbConnection connection)
        {
            _dataApi = new KnowYourKnockoutDataApi(connection);
        }

        #endregion

        #region METHODS

        public List<FriendRequest> GetPendingRequests(Guid userId)
        {
            return _dataApi.FriendRequests.Get(r => r.RequesteeId == userId && r.IsActive);
        }

        public List<FriendRequest> GetSentRequests(Guid userId)
        {
            return _dataApi.FriendRequests.Get(r => r.RequesterId == userId && r.IsActive);
        }

        public bool AcceptFriendRequest(Guid friendRequestId)
        {
            var friendRequest = _dataApi.FriendRequests.Get(friendRequestId);

            friendRequest.IsAccepted = true;
            friendRequest.RespondedOn = DateTime.Now;

            return _dataApi.FriendRequests.Update(friendRequest);
        }

        public bool RejectFriendRequest(Guid friendRequestId)
        {
            var friendRequest = _dataApi.FriendRequests.Get(friendRequestId);

            friendRequest.IsActive = false;
            friendRequest.RespondedOn = DateTime.Now;

            return _dataApi.FriendRequests.Update(friendRequest);
        }

        public FriendRequest SendFriendRequest(Guid requesterId, Guid requesteeId)
        {
            return _dataApi.FriendRequests.Add(new FriendRequest()
            {
                RequesteeId = requesteeId,
                RequesterId = requesterId
            });
        }

        //public FriendRequest SendFriendRequest(Guid requesterId, string requesteeEmailAddress)
        //{




        //    var requesteeId = Guid.NewGuid();

        //    return _dataApi.FriendRequests.Add(new FriendRequest()
        //    {
        //        RequesteeId = requesteeId,
        //        RequesterId = requesterId
        //    });
        //}

        public bool Defriend(Guid friendRequestId)
        {
            var friendRequest = _dataApi.FriendRequests.Get(friendRequestId);

            return _dataApi.FriendRequests.Remove(friendRequest);
        }
        
        #endregion
    }
}
