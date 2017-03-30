using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Business
{
    public class UserLogic// : LogicBase
    {
        private IKnowYourKnockoutDataApi _dataApi;

        public UserLogic(IKnowYourKnockoutDataApi dataApi)
        {
            _dataApi = dataApi;
        }

        #region Basic CRUD Ops

        public List<User> GetUsers()
        {
            try
            {
                return _dataApi.UserRepository.Get();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public User GetUser(int id)
        {
            try
            {
                return _dataApi.UserRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User AddUser(User user)
        {
            try
            {
                return _dataApi.UserRepository.Add(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(User user, bool isHardDelete = false)
        {
            try
            {
                return isHardDelete ? 
                    _dataApi.UserRepository.HardDelete(user) :
                    _dataApi.UserRepository.SoftDelete(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUserProfile(User user)
        {
            try
            {
                return _dataApi.UserRepository.Update(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        // TODO: Investigate if this should be provate or even need to be called in the UsersController
        public bool UserExists(string emailAddress)
        {
            return _dataApi.UserRepository.Get(u => u.EmailAddress == emailAddress).Any();
        }

        // TODO: Refactor this shit...
        public User SignInUser(User user)
        {
            if (!_dataApi.UserRepository.Get(u => u.FirebaseId == user.FirebaseId).Any())
            {
                return _dataApi.UserRepository.Add(user);
            }

            var storedUser = _dataApi.UserRepository.Get(u => u.FirebaseId == user.FirebaseId).Single();

            if (storedUser.DisplayName != user.DisplayName ||
                storedUser.PhotoUrl != user.PhotoUrl)
            {
                if (!_dataApi.UserRepository.Update(user))
                {
                    throw new Exception("Could not update user profile...");
                }
            }

            return storedUser;
        }

        public void ActivateAccount(User user)
        {
            // TODO: Figure out how the exception handling should work...
            try
            {
                user.IsActive = true;

                if (!_dataApi.UserRepository.Update(user))
                {
                    throw new Exception($"Could not activate account for user with firebase id: {user.FirebaseId}");
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not activate account for user with firebase id: {user.FirebaseId}", ex);
            }
        }
    }
}
