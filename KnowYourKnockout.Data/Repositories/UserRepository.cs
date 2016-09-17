using KnowYourKnockout.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public class UserRepository
        : IKnowYourKnockoutRepository<User, Guid>
    {
        private IKnowYourKnockoutContext _context;

        public UserRepository(IKnowYourKnockoutContext context)
        {
            _context = context;
        }

        public User Add(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public List<User> Get()
        {
            return _context.User.ToList();
        }

        public User Get(Guid id)
        {
            return _context.User.Single(u => u.Id == id);
        }

        public List<User> Get(Expression<Func<User, bool>> expression)
        {
            return _context.User.Where(expression).ToList();
        }

        public bool HardDelete(User user)
        {
            _context.User.Remove(user);
            return _context.SaveChanges() == 1;
        }

        public bool SoftDelete(User user)
        {
            user.IsActive = false;
            return Update(user);
        }

        public bool Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return _context.SaveChanges() == 1;
        }
    }
}
