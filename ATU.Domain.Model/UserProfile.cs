using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATU.Domain.Model
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(40)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateCreatedUtc { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }

        public int Status { get; set; }
    }
}