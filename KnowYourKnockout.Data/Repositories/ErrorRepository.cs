using KnowYourKnockout.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public class ErrorRepository
        : IKnowYourKnockoutRepository<Error, Guid>
    {
        public Error Add(Error error)
        {
            throw new NotImplementedException();
        }

        public List<Error> Get()
        {
            throw new NotImplementedException();
        }

        public Error Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Error> Get(Expression<Func<Error, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool HardDelete(Error error)
        {
            throw new NotImplementedException();
        }

        public bool SoftDelete(Error error)
        {
            throw new NotImplementedException();
        }

        public bool Update(Error error)
        {
            throw new NotImplementedException();
        }
    }
}
