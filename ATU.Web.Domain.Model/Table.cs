using System.Collections.Generic;

namespace ATU.Web.Domain.Model
{
    public class Table
    {
        public Table()
        {
            ItemsPerPage = new List<int>();
            Rows = new List<Row>();
        }

        public string Title { get; set; }
        public List<int> ItemsPerPage { get; set; }
        public List<string> TableHeaders { get; set; }        
        public List<Row> Rows { get; set; }
    }
}