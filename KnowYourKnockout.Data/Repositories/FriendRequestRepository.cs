using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public class FriendRequestRepository 
        : IRepository<FriendRequest, Guid>
    {
        private KnowYourKnockoutDataContext _context;

        internal FriendRequestRepository(KnowYourKnockoutDataContext context)
        {
            _context = context;
        }

        public FriendRequest Add(FriendRequest entity)
        {
            _context.FriendRequest.Add(entity);
            _context.SaveChanges();
            _context.Entry(entity).Reload();

            return entity;
        }

        public List<FriendRequest> Get()
        {
            return _context.FriendRequest.ToList();
        }

        public List<FriendRequest> Get(Expression<Func<FriendRequest, bool>> expression)
        {
            return _context.FriendRequest.Where(expression).ToList();
        }

        public FriendRequest Get(Guid id)
        {
            return _context.FriendRequest.Find(id);
        }

        public bool Remove(FriendRequest entity)
        {
            _context.FriendRequest.Remove(entity);

            return _context.SaveChanges() == 1;
        }

        public bool Update(FriendRequest entity)
        {
            _context.FriendRequest.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges() == 1;
        }
    }
}
