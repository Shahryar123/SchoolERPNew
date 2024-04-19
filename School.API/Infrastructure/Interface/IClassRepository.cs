using DemoAttendenceFeature.Entities;
using SchoolApp.API.Entities;

namespace DemoAttendenceFeature.Infrastructure.Interface
{
    public interface IClassRepository
    {
        public Task<int> CreateClass(Classes Class);
        public Task<Classes?> GetClassById(int id, bool includeAll = false);
        public Task<IEnumerable<Classes>?> GetAllClasss(bool includeAll=false);
        public Task<Classes?> UpdateClass(Classes Class);
        public Task<bool> DeleteClass(Classes Class);

        Task Save();
    }
}