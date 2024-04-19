using SchoolApp.API.Entities;

namespace SchoolApp.API.Infrastructure.Interface
{
    public interface IClassesSectionsRepository
    {
        public Task AddClassesSection(ClassesSections classesSection);
    }

}
