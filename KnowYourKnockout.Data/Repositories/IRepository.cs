using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public interface IRepository<TEnt, in TPk> where TEnt : class
    {
        List<TEnt> Get();
        List<TEnt> Get(Expression<Func<TEnt, bool>> expression);
        TEnt Get(TPk id);
        TEnt Add(TEnt entity);
        bool Update(TEnt entity);
        bool Remove(TEnt entity);
    }
}
