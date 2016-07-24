using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public class UserRepository
        : IRepository<User, Guid>
    {
        private KnowYourKnockoutDataContext _context;

        internal UserRepository(KnowYourKnockoutDataContext context)
        {
            _context = context;
        }

        public User Add(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
            _context.Entry(entity).Reload();

            return entity;
        }

        public List<User> Get()
        {
            return _context.User.ToList();
        }

        public List<User> Get(Expression<Func<User, bool>> expression)
        {
            return _context.User.Where(expression).ToList();
        }

        public User Get(Guid id)
        {
            return _context.User.Find(id);
        }

        public bool Remove(User entity)
        {
            _context.User.Remove(entity);

            return _context.SaveChanges() == 1;
        }

        public bool Update(User entity)
        {
            _context.User.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges() == 1;
        }
    }
}
