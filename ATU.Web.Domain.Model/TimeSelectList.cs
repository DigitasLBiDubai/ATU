using System.Web.Mvc;

namespace ATU.Web.Domain.Model
{
    public class TimeSelectList
    {
        public string SelectedValue { get; set; }

        public SelectList TimesOfTheDay { get; set; }
    }
}
