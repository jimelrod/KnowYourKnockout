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

        public List<User> GetUsers()
        {
            try
            {
                return _dataApi.UserRepository.Get();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return null;
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
                Console.Write(ex.Message);
                return null;
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
                Console.Write(ex.Message);
                return null;
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
                Console.Write(ex.Message);
                return false;
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
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
