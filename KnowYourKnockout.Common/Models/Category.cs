using System;
using System.Collections.Generic;

namespace KnowYourKnockout.Data.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}
