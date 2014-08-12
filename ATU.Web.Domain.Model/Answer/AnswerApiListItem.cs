using System;

namespace ATU.Web.Domain.Model.Answer
{
    public class AnswerApiListItem
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool Verified { get; set; }

        public DateTime DateCreated { get; set; }
    }
}