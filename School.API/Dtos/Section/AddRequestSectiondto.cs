using DemoAttendenceFeature.Dtos.Guardian;
using DemoAttendenceFeature.Entities;
using SchoolApp.API.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoAttendenceFeature.Dtos.Section
{
    public class AddRequestSectiondto
    {
        
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public int DepartmentId { get; set; }

    }

}
