using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolApp.API.Entities
{
    [Table("Sections")]
    public class Sections
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Classes> Classes { get; set; }
    }
}
