using KnowYourKnockout.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SqlClient;
using KnowYourKnockout.Data.Exceptions;

namespace KnowYourKnockout.Data.Repositories
{
    public class UserRepository
        : IKnowYourKnockoutRepository<User, int>
    {
        private IKnowYourKnockoutContext _context;

        public UserRepository(IKnowYourKnockoutContext context)
        {
            _context = context;
        }

        public User Add(User entity)
        {
            try
            {
                _context.User.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch(DbUpdateException ex)
            {
                if (ex.InnerException is SqlException)
                {
                    var sEx = (SqlException)ex.InnerException;

                    switch (sEx.Number)
                    {
                        // Violates UNIQUE constraint
                        // Depending on need, messages may move to a dictionary[code]
                        case 2627:
                            throw new KykDataLayerException(ExceptionType.Client, "Record in Users already exists with secified value. See Inner Exception for details.", sEx);

                    }
                }

                throw ex;
            }
            catch (Exception ex)
            {
                // Log with high priority
                throw ex;
            }
        }

        public List<User> Get()
        {
            try
            {
                return _context.User.ToList();
            }
            catch (Exception ex)
            {
                // Log with high priority
                throw ex;
            }
        }

        public User Get(int id)
        {
            try
            {
                var user = _context.User.Single(u => u.Id == id);
                return user;
            }
            catch (InvalidOperationException)
            {
                // No records
                return null;
            }
            catch (Exception ex)
            {
                // Log with high priority
                throw ex;
            }
        }

        public List<User> Get(Expression<Func<User, bool>> expression)
        {
            try
            {
                return _context.User.Where(expression).ToList();
            }
            catch (Exception ex)
            {
                // Log with high priority
                throw ex;
            }
        }

        public bool HardDelete(User user)
        {
            try
            {
                _context.User.Remove(user);
                return _context.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                // Log with high priority
                throw ex;
            }
        }

        public bool SoftDelete(User user)
        {
            try
            {
                user.IsActive = false;
                return Update(user);
            }
            catch (Exception ex)
            {
                // Log with high priority
                throw ex;
            }
        }

        public bool Update(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                return _context.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                // Log with high priority
                throw ex;
            }
        }
    }
}
