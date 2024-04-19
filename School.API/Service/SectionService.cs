using AutoMapper;
using DemoAttendenceFeature.Dtos.Section;
using DemoAttendenceFeature.Infrastructure.Interface;
using SchoolApp.API.Entities;

namespace DemoAttendenceFeature.Service
{
    public class SectionService
    {
        private readonly ISectionRepository _SectionRepository;
        private readonly IMapper _mapper;

        public SectionService(ISectionRepository SectionRepository, IMapper mapper)
        {
            _SectionRepository = SectionRepository;
            _mapper = mapper;
        }

        public async Task<GetResponsSectionDto?> GetSectionById(int sectionId)
        {
            var sectionInfo = await _SectionRepository.GetSectionById(sectionId);
            if(sectionInfo != null)
            {
                var sectionDto =_mapper.Map<GetResponsSectionDto>(sectionInfo);
                return sectionDto;
            }
            return null;
        }
        public async Task<int> CreateSection(AddRequestSectiondto createSectionDto)
        {
            var section = _mapper.Map<Sections>(createSectionDto);
            var sectionId = await _SectionRepository.CreateSection(section);
            return sectionId;
        }

        public async Task<GetResponsSectionDto?> UpdateSection(int sectionId, AddRequestSectiondto requestDto)
        {
            var existingSection = await _SectionRepository.GetSectionById(sectionId);

            if (existingSection != null)
            {
                _mapper.Map(requestDto, existingSection);
                existingSection = await _SectionRepository.UpdateSection(existingSection);
                var updatedSectionDto = _mapper.Map<GetResponsSectionDto>(existingSection);

                return updatedSectionDto;
            }
            return null;
        }
        public async Task<IEnumerable<GetResponsSectionDto>?> GetAllSections()
        {
            var sectionInfo = await _SectionRepository.GetAllSections();
            if (sectionInfo != null)
            {
                var sectionDto = _mapper.Map<List<GetResponsSectionDto>>(sectionInfo);
                return sectionDto;
            }
            return null;
        }

        public async Task<bool> DeleteSection(int sectionId)
        {
            var sectionInfo = await _SectionRepository.GetSectionById(sectionId);
            if (sectionInfo != null)
            {
                return await _SectionRepository.DeleteSection(sectionInfo);
            }
            return false;
        }


    }
}
