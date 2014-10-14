using System;
using System.ComponentModel.DataAnnotations;

namespace ATU.Web.Domain.Model.Question
{
    public class QuestionFields
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public Guid authToken { get; set; }
    }
}