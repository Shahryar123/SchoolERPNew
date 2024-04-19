using AutoMapper;
using DemoAttendenceFeature.Dtos.Class;
using DemoAttendenceFeature.Dtos.Student;
using DemoAttendenceFeature.Infrastructure;
using DemoAttendenceFeature.Infrastructure.Interface;
using SchoolApp.API.Dtos.ClassSection;
using SchoolApp.API.Entities;
using SchoolApp.API.Infrastructure.Interface;

namespace SchoolApp.API.Service
{
    public class ClassSectionService
    {
        private readonly IClassRepository _classRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IClassesSectionsRepository _classesSectionsRepository;
        private readonly IMapper _mapper;
        public ClassSectionService(IClassesSectionsRepository classesSectionsRepository , IClassRepository classRepository, ISectionRepository sectionRepository, IMapper mapper)
        {
            _classesSectionsRepository = classesSectionsRepository;
            _classRepository = classRepository;
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<GetResponseClassSectionDto?> AddSection(int classId, int sectionId, int capacity)
        {
            var classes = await _classRepository.GetClassById(classId, true);
            var section = await _sectionRepository.GetSectionById(sectionId);

            if (classes != null && section != null)
            {
                // Create a new instance of ClassesSections
                var classesSection = new ClassesSections
                {
                    Class = classes,
                    Section = section,
                    Capacity = capacity
                };

                // Add the ClassesSections instance
                await _classesSectionsRepository.AddClassesSection(classesSection);

                var classSectionDto = new GetResponseClassSectionDto
                {
                    ClassId = classes.Id,
                    ClassName = classes.Name,
                    SectionId = section.Id,
                    SectionName = section.Name,
                    Capacity = capacity
                };

                return classSectionDto;
            }
            return null;
        }



    }
}