using System.Collections.Generic;

namespace ATU.Web.Domain.Model
{
    public class RadioButtonList
    {
        public RadioButtonList()
        {
            RadioButtons = new List<RadioButton>();
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public string SelectedValue { get; set; }
        public List<RadioButton> RadioButtons { get; set; }
    }
}