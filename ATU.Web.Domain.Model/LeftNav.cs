using System.Collections.Generic;

namespace ATU.Web.Domain.Model
{
    public class LeftNav
    {
        public LeftNav() 
        {
            LeftNavSections = LeftNavSections ?? new List<LeftNavSection>();
        }

        public Link Link { get; set; }

        public List<LeftNavSection> LeftNavSections { get; set; }
    }
}