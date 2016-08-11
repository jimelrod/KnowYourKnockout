using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AskerId { get; set; }
        public Guid ResponderId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public bool IsQuestionPublic { get; set; }
        public bool IsAnswerPublished { get; set; }
        public DateTime AskedOn { get; set; }
        public DateTime? AnsweredOn { get; set; }

        [InverseProperty("Id")]
        public virtual List<Tag> Tags { get; set; }
        [ForeignKey("AskerId")]
        public virtual User Asker { get; set; }
        [ForeignKey("ResponderId")]
        public virtual User Responder { get; set; }
    }
}
