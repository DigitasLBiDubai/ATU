
namespace ATU.Web.Domain.Model
{
    public class Link
    {
        public Link(string name, string url, string cssClass, string iconCssClass)
        {
            Name = name;
            Url = url;
            CssClass = cssClass;
            IconCssClass = iconCssClass;
        }

        public Link(string name, string url, string cssClass)
        {
            Name = name;
            Url = url;
            CssClass = cssClass;
        }

        public string Name { get; set; }

        public string Url { get; set; }

        public string CssClass { get; set; }

        public string IconCssClass { get; set; }
    }
}