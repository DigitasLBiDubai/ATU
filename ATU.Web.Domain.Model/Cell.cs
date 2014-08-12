
namespace ATU.Web.Domain.Model
{
    public class Cell
    {
        public Cell(object value, bool centered)
        {
            Value = value;
            Centered = centered;
        }

        public object Value { get; set; }
        public bool Centered { get; set; }
    }
}