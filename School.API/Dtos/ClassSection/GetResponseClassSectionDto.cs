namespace SchoolApp.API.Dtos.ClassSection
{
    public class GetResponseClassSectionDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; } 
        public int Capacity { get; set; } 
    }
}
