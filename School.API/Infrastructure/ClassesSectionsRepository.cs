using DemoAttendenceFeature.Data;
using SchoolApp.API.Entities;
using SchoolApp.API.Infrastructure.Interface;

namespace SchoolApp.API.Infrastructure
{
    public class ClassesSectionsRepository : IClassesSectionsRepository
    {
        private readonly AppDbContext _context;

        public ClassesSectionsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddClassesSection(ClassesSections classesSection)
        {
            _context.ClassesSections.Add(classesSection);
            await _context.SaveChangesAsync();
        }
    }

}
