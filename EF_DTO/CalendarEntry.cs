using System.ComponentModel.DataAnnotations;

namespace EF_DTO
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
