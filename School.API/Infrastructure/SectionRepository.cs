using DemoAttendenceFeature.Data;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Helper.Constant_Enums;
using DemoAttendenceFeature.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using SchoolApp.API.Entities;

namespace SchoolApp.API.Infrastructure
{
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _dbContext;

        public SectionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateSection(Sections Section)
        {
            var sectiondata = await _dbContext.sections.AddAsync(Section);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? sectiondata.Entity.Id : -1;
        }

        public async Task<IEnumerable<Sections>?> GetAllSections()
        {
            return await _dbContext.sections
                    .ToListAsync();
        }


        public async Task<Sections?> GetSectionById(int id)
        {
            return await _dbContext.sections
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Sections?> UpdateSection(Sections Section)
        {
            var exsistingSection = await _dbContext.sections.FirstOrDefaultAsync(x => x.Id == Section.Id);
            if (exsistingSection != null)
            {
                _dbContext.Entry(exsistingSection).CurrentValues.SetValues(Section);
                _dbContext.Entry(exsistingSection).Property(x => x.Id).IsModified = false;
                await _dbContext.SaveChangesAsync();
                return exsistingSection;
            }
            return null;
        }

        public async Task<bool> DeleteSection(Sections Section)
        {
            _dbContext.sections.Remove(Section);
            return await _dbContext.SaveChangesAsync() > 0;
        }



    }
}
