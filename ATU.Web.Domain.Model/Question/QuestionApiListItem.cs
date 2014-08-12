using System;

namespace ATU.Web.Domain.Model.Question
{
    public class QuestionApiListItem
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }
    }
}