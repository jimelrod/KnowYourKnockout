using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public interface IViewRepository<TEnt> where TEnt : class
    {
        List<TEnt> Get();
        List<TEnt> Get(Expression<Func<TEnt, bool>> expression);
    }
}
