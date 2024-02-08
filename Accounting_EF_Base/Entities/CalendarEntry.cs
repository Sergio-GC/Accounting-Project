using System.ComponentModel.DataAnnotations;

namespace Accounting_EF_Base.Entities
{
    public class CalendarEntry
    {
        [Key]
        public int Id { get; set; }
        public virtual Kid Kid { get; set; }
        public DateTime Date { get; set; }
        public string Data { get; set; }
        public bool Validated { get; set; }
        public virtual Price Price { get; set; }
    }
}
