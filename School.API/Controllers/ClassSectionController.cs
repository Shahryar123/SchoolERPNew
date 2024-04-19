using DemoAttendenceFeature.Dtos.Class;
using DemoAttendenceFeature.Dtos.ClassSection;
using DemoAttendenceFeature.ExampleResponse;
using DemoAttendenceFeature.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.API.Dtos.ClassSection;
using SchoolApp.API.Service;
using System.Net;

namespace SchoolApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSectionController : ControllerBase
    {
        private readonly ClassSectionService _classSectionService;

        public ClassSectionController(ClassSectionService classSectionService)
        {
            _classSectionService = classSectionService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetResponseClassDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseClassSectionDto>> AssignSection(AddRequestClassSectionDto requestDto)
        {
            try
            {
                var response = await _classSectionService.AddSection(requestDto.ClassId, requestDto.SectionId,requestDto.Capacity);
                if (response == null)
                {
                    return NotFound(new { message = "Failed to Create Class" });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
