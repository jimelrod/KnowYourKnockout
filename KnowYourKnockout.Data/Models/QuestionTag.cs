using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    public class QuestionTag
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int TagId { get; set; }
        
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
