using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace KnowYourKnockout.Business
{
    public class UserLogic
    {
        #region FIELDS

        private KnowYourKnockoutDataApi _dataApi;

        #endregion

        #region CONSTRUCTORS

        internal UserLogic()
        {
            _dataApi = new KnowYourKnockoutDataApi();
        }

        internal UserLogic(string connectionString)
        {
           _dataApi = new KnowYourKnockoutDataApi(connectionString);
        }

        internal UserLogic(DbConnection connection)
        {
            _dataApi = new KnowYourKnockoutDataApi(connection);
        }

        #endregion

        #region METHODS

        public User Get(Guid id)
        {
            return _dataApi.Users.Get(id);
        }

        public List<User> Get()
        {
            return _dataApi.Users.Get();
        }

        public User SignUp(string emailAddress, string firstName, string lastName)
        {
            return _dataApi.Users.Add(new User()
            {
                EmailAddress = emailAddress,
                FirstName = firstName,
                LastName = lastName
            });
        }

        public User SignUp(User user)
        {
            user.IsActive = true;
            return _dataApi.Users.Add(user);
        }

        public bool ConfirmSignup(Guid id)
        {
            var user = _dataApi.Users.Get(id);

            user.IsActive = true;
            user.JoinedOn = DateTime.Now;

            return _dataApi.Users.Update(user);
        }

        public bool UpdateProfile(Guid id, string emailAddress, string firstName, string lastName)
        {
            var user = _dataApi.Users.Get(id);

            user.EmailAddress = emailAddress;
            user.FirstName = firstName;
            user.LastName = lastName;

            return _dataApi.Users.Update(user);
        }

        public bool UpdateProfile(User user)
        {
            return _dataApi.Users.Update(user);
        }

        public bool Delete(Guid id)
        {
            var user = _dataApi.Users.Get(id);

            return _dataApi.Users.Remove(user);
        }

        public bool Delete(User user)
        {
            return _dataApi.Users.Remove(user);
        }

        #endregion
    }
}
