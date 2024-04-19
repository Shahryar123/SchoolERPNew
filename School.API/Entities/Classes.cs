using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace SchoolApp.API.Entities
{
    [Table("Classes")]
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Sections> Sections { get; set; }
    }
}
