using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KnowYourKnockout.Data.Repositories
{
    public class QuestionRepository
        : IRepository<Question, Guid>
    {
        private KnowYourKnockoutDataContext _context;

        internal QuestionRepository(KnowYourKnockoutDataContext context)
        {
            _context = context;
        }

        public Question Add(Question entity)
        {
            _context.Question.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public List<Question> Get()
        {
            return _context.Question.ToList();
        }

        public List<Question> Get(Expression<Func<Question, bool>> expression)
        {
            return _context.Question.Where(expression).ToList();
        }

        public Question Get(Guid id)
        {
            return _context.Question.Find(id);
        }

        public bool Remove(Question entity)
        {
            _context.Question.Remove(entity);

            return _context.SaveChanges() == 1;
        }

        public bool Update(Question entity)
        {
            _context.Question.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges() == 1;
        }
    }
}
