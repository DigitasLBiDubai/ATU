using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATU.Domain.Model
{
    [Table("Request")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Text { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(40)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required, StringLength(80)]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Required, StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int RequestType { get; set; }

        public User From { get; set; }

        public User To { get; set; }

        public int Status { get; set; }

        [Required]
        public DateTime CreatedUtc { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }
    }
}
