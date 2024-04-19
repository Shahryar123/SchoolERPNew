using DemoAttendenceFeature.Entities;
using SchoolApp.API.Entities;

namespace DemoAttendenceFeature.Infrastructure.Interface
{
    public interface ISectionRepository
    {
        public Task<int> CreateSection(Sections section);
        public Task<Sections?> GetSectionById(int id);
        public Task<IEnumerable<Sections>?> GetAllSections();
        public Task<Sections?> UpdateSection(Sections section);
        public Task<bool> DeleteSection(Sections section);

        Task Save();
    }
}