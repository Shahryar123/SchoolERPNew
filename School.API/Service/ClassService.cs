using AutoMapper;
using DemoAttendenceFeature.Dtos.Class;
using DemoAttendenceFeature.Infrastructure.Interface;
using SchoolApp.API.Entities;

namespace DemoAttendenceFeature.Service
{
    public class ClassService
    {
        private readonly IClassRepository _ClassRepository;
        private readonly IMapper _mapper;

        public ClassService(IClassRepository ClassRepository, IMapper mapper)
        {
            _ClassRepository = ClassRepository;
            _mapper = mapper;
        }

        public async Task<GetResponseClassDto?> GetClassById(int ClassId)
        {
            var ClassInfo = await _ClassRepository.GetClassById(ClassId, true);
            if(ClassInfo != null)
            {
                var ClassDto =_mapper.Map<GetResponseClassDto>(ClassInfo);
                return ClassDto;
            }
            return null;
        }
        public async Task<int> CreateClass(AddRequestClassdto createClassDto)
        {
            var Class = _mapper.Map<Classes>(createClassDto);
            var ClassId = await _ClassRepository.CreateClass(Class);
            return ClassId;
        }

        public async Task<GetResponseClassDto?> UpdateClass(int ClassId, AddRequestClassdto requestDto)
        {
            var existingClass = await _ClassRepository.GetClassById(ClassId);

            if (existingClass != null)
            {
                _mapper.Map(requestDto, existingClass);
                existingClass = await _ClassRepository.UpdateClass(existingClass);
                var updatedClassDto = _mapper.Map<GetResponseClassDto>(existingClass);

                return updatedClassDto;
            }
            return null;
        }
        public async Task<IEnumerable<GetResponseClassDto>?> GetAllClasss()
        {
            var ClassInfo = await _ClassRepository.GetAllClasss(true);
            if (ClassInfo != null)
            {
                var ClassDto = _mapper.Map<List<GetResponseClassDto>>(ClassInfo);
                return ClassDto;
            }
            return null;
        }

        public async Task<bool> DeleteClass(int ClassId)
        {
            var ClassInfo = await _ClassRepository.GetClassById(ClassId);
            if (ClassInfo != null)
            {
                return await _ClassRepository.DeleteClass(ClassInfo);
            }
            return false;
        }


    }
}
