using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATU.Domain.Model
{
    [Table("Question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual List<Answer> Answers { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}