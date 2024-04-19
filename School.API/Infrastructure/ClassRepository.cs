using DemoAttendenceFeature.Data;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Helper.Constant_Enums;
using DemoAttendenceFeature.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using SchoolApp.API.Entities;

namespace SchoolApp.API.Infrastructure
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _dbContext;

        public ClassRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateClass(Classes Class)
        {
            var Classdata = await _dbContext.classes.AddAsync(Class);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? Classdata.Entity.Id : -1;
        }

        public async Task<IEnumerable<Classes>?> GetAllClasss(bool inlcudeAll = false)
        {
            return await _dbContext.classes
                    .ToListAsync();
        }


        public async Task<Classes?> GetClassById(int id, bool inlcudeAll = false)
        {
            return await _dbContext.classes
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Classes?> UpdateClass(Classes Class)
        {
            var exsistingClass = await _dbContext.classes.FirstOrDefaultAsync(x => x.Id == Class.Id);
            if (exsistingClass != null)
            {
                _dbContext.Entry(exsistingClass).CurrentValues.SetValues(Class);
                _dbContext.Entry(exsistingClass).Property(x => x.Id).IsModified = false;
                await _dbContext.SaveChangesAsync();
                return exsistingClass;
            }
            return null;
        }

        public async Task<bool> DeleteClass(Classes Class)
        {
            _dbContext.classes.Remove(Class);
            return await _dbContext.SaveChangesAsync() > 0;
        }



    }
}
