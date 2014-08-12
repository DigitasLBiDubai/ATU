
namespace ATU.Web.Domain.Model
{
    public class ViewBase
    {
        public string PortalTitle { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Icon { get; set; }
        public TopNav TopNav { get; set; }
        public LeftNav LeftNav { get; set; }
        public Breadcrumb Breadcrumb { get; set; }
    }
}