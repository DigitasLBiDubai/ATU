using System;
using System.Collections.Generic;
using ATU.Web.Domain.Model.Answer;

namespace ATU.Web.Domain.Model.Question
{
    public class QuestionApiListItem
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public List<AnswerApiListItem> Answers { get; set; }

        public CategoryApiListItem Category { get; set; }
    }
}