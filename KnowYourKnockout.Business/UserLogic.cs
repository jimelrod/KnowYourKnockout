using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Business
{
    public class UserLogic// : LogicBase
    {
        private IKnowYourKnockoutDataApi _dataApi;
        private Log _log;

        public UserLogic(IKnowYourKnockoutDataApi dataApi, Log log)
        {
            _dataApi = dataApi;
            _log = log;
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
                _log.Insert(ex, GetType().ToString(), "GetUsers()");
                throw ex;
            }
        }

        public User GetUser(Guid id)
        {
            try
            {
                return _dataApi.UserRepository.Get(id);
            }
            catch (Exception ex)
            {
                _log.Insert(ex, GetType().ToString(), "GetUser(Guid id)");
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
                _log.Insert(ex, GetType().ToString(), "AddUser(User user)");
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
                _log.Insert(ex, GetType().ToString(), "DeleteUser(User user, bool isHardDelete = false)");
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
                _log.Insert(ex, GetType().ToString(), "UpdateUserProfile(User user)");
                throw ex;
            }
        }

        #endregion

        // MAY NOT NEED!!!
        public bool UserExists(string emailAddress)
        {
            return _dataApi.UserRepository.Get(u => u.EmailAddress == emailAddress).Any();
        }
    }
}
