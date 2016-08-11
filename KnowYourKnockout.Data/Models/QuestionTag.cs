using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.Data.Models
{
    public class QuestionTag
    {
        public Guid QuestionId { get; set; }
        public Guid TagId { get; set; }
    }
}
