using System.Collections.Generic;

namespace ATU.Web.Domain.Model
{
    public class Row
    {
        public Row()
        {
            Cells = new List<Cell>();
        }

        public string Id { get; set; }
        public List<Cell> Cells { get; set; }
    }
}