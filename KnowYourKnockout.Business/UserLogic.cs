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
        private KnowYourKnockoutContext _context;

        public UserLogic(KnowYourKnockoutContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();

            try
            {
                users = _context.User.ToList();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }

            return users;
        }

        public User AddUser(User user)
        {
            try
            {
                _context.User.Add(user);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                user = null;
            }

            return user;
        }
    }
}
