using System.ComponentModel.DataAnnotations;

namespace EF_DTO
{
    public class Kid
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Birthdate { get; set; }


        public virtual ICollection<SiblingRelationship>? Siblings { get; set; }
    }
}
