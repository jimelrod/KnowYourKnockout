using System;
using System.Collections.Generic;

namespace KnowYourKnockout.Data.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid AskerId { get; set; }
        public Guid ResponderId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public bool IsQuestionPublic { get; set; }
        public bool IsAnswerPublished { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime AskedOn { get; set; }
        public DateTime? AnsweredOn { get; set; }

        public virtual List<Tag> Tags { get; set; }
        public virtual User Asker { get; set; }
        public virtual User Responder { get; set; }
    }
}
