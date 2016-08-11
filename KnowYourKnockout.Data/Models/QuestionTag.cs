using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    public class QuestionTag
    {
        public Guid QuestionId { get; set; }
        public Guid TagId { get; set; }

        [ForeignKey("Id")]
        public virtual Tag Tag { get; set; }
        [ForeignKey("Id")]
        public virtual Question Question { get; set; }
    }
}
