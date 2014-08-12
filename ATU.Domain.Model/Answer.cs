using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATU.Domain.Model
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public bool Verified { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

    }
}