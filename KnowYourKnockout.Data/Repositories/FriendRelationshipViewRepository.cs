using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public class FriendRelationshipViewRepository
        : IViewRepository<FriendRelationship>
    {
        private KnowYourKnockoutDataContext _context;

        internal FriendRelationshipViewRepository(KnowYourKnockoutDataContext context)
        {
            _context = context;
        }

        public List<FriendRelationship> Get()
        {
            return _context.FriendRelationship.ToList();
        }

        public List<FriendRelationship> Get(Expression<Func<FriendRelationship, bool>> expression)
        {
            return _context.FriendRelationship.Where(expression).ToList();
        }
    }
}
