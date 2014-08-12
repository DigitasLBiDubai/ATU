using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Abstract
{
    public interface IBreadcrumbFactory
    {
        Breadcrumb BuildBreadcrumb();
    }
}