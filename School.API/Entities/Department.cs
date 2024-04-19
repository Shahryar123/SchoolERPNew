using DemoAttendenceFeature.Entities;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.API.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Classes> classes { get; set; }
        public ICollection<Sections> sections { get; set; }

    }
}
