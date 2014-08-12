using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Concrete
{
    public class BreadcrumbFactory : IBreadcrumbFactory
    {
        private BreadcrumbItem BuildBreadcrumbItem(string name, string iconName, string styleCssClass, string colourCssClass)
        {
            return new BreadcrumbItem
            {
                Text = name,
                IconName = iconName,
                CssClass = styleCssClass, // breadcrumb-button
                CssClassColour = colourCssClass // blue
            };
        }

        public Breadcrumb BuildBreadcrumb()
        {
            var breadcrumb = new Breadcrumb();

            breadcrumb.BreadcrumbItems.Add(BuildBreadcrumbItem("Home", "icon", "breadcrumb-button", "blue"));
            breadcrumb.BreadcrumbItems.Add(BuildBreadcrumbItem("Dashboard", "icon", "breadcrumb-button", string.Empty));

            return breadcrumb;
        }
    }
}