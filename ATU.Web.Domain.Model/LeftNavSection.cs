using System.Collections.Generic;

namespace ATU.Web.Domain.Model
{
    public class LeftNavSection
    {
        public LeftNavSection() 
        {
            Links = Links ?? new List<Link>();
        }

        public Link Link { get; set; }

        public List<Link> Links { get; set; }
    }
}