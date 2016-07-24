using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    [Table("Question")]
    public class Question
    {
        public Question()
        {
            IsQuestionPublic = false;
            IsAnswerPublished = false;
            AskedOn = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual User Asker { get; set; }
        [JsonIgnore]
        public virtual User Responder { get; set; }
    }
}
