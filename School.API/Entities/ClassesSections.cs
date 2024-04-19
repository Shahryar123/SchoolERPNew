namespace SchoolApp.API.Entities
{
    public class ClassesSections
    {
        public int ClassId { get; set; }
        public Classes Class { get; set; }

        public int SectionId { get; set; }
        public Sections Section { get; set; }

        public int Capacity { get; set; } // Add Capacity property
    }

}
