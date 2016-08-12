﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourKnockout.Data.Models
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        //[InverseProperty("TagId")]
        public virtual List<QuestionTag> QuestionTags { get; set; }
    }
}
