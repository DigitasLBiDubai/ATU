using System.Collections.Generic;

namespace ATU.Web.Domain.Model
{
    public class Breadcrumb
    {
        public Breadcrumb()
        {
            BreadcrumbItems = BreadcrumbItems ?? new List<BreadcrumbItem>();
        }

        public List<BreadcrumbItem> BreadcrumbItems { get; set; }
    }
}