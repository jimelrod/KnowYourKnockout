using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public List<User> Get(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool HardDelete(User entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftDelete(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
