using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public class CategoryRepository
        : IRepository<Category, Guid>
    {
        private KnowYourKnockoutDataContext _context;

        internal CategoryRepository(KnowYourKnockoutDataContext context)
        {
            _context = context;
        }

        public Category Add(Category entity)
        {
            _context.Category.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public List<Category> Get()
        {
            return _context.Category.ToList();
        }

        public List<Category> Get(Expression<Func<Category, bool>> expression)
        {
            return _context.Category.Where(expression).ToList();
        }

        public Category Get(Guid id)
        {
            return _context.Category.Find(id);
        }

        public bool Remove(Category entity)
        {
            _context.Category.Remove(entity);

            return _context.SaveChanges() == 1;
        }

        public bool Update(Category entity)
        {
            _context.Category.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges() == 1;
        }
    }
}
