using DemoAttendenceFeature.Dtos.Guardian;
using SchoolApp.API.Entities;

namespace DemoAttendenceFeature.Dtos.Class
{
    public class GetResponseClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

    }
}
