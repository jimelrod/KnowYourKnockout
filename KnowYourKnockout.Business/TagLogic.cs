using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Business
{
    public class TagLogic
    {
        private KnowYourKnockoutContext _context;
        
        public TagLogic(KnowYourKnockoutContext context)
        {
            _context = context;
        }

        public List<Tag> GetTags(out Exception exception)
        {
            exception = null;
            var tags = new List<Tag>();

            try
            {                
                tags = _context.Tag.ToList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return tags;
        }
    }
}
