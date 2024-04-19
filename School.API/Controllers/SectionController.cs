using Azure;
using DemoAttendenceFeature.Dtos.Admission;
using DemoAttendenceFeature.Dtos.Section;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.ExampleResponse;
using DemoAttendenceFeature.Infrastructure.Interface;
using DemoAttendenceFeature.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoAttendenceFeature.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly SectionService _SectionService;

        public SectionController(SectionService SectionService)
        {
            _SectionService = SectionService;
        }

        [HttpGet("{Id:int}", Name = "GetSection")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetResponsSectionDto),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponsSectionDto>> GetSection(int Id)
        {
            try
            {
                var Section = await _SectionService.GetSectionById(Id);
                if (Section == null)
                {
                    return NotFound(new { message = "Section Not Found" });
                }
                return Ok(Section);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
            
        }


        [HttpPost]
        [ProducesResponseType(typeof(GetResponsSectionDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponsSectionDto>> CreateSection([FromBody]AddRequestSectiondto SectionDto)
        {
            try
            {
                var Section = await _SectionService.CreateSection(SectionDto);
                if (Section == null)
                {
                    return BadRequest(new { message = "Failed to Create Section" });
                }
                return Ok(Section);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new {message= ex.Message });
            }

        }


        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<GetResponsSectionDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponsSectionDto>> GetSections()
        {

            try
            {
                var Sections = await _SectionService.GetAllSections();
                if (Sections == null)
                {
                    return NotFound(new { message = "No Section Found" });
                }
                return Ok(Sections);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<string>> DeleteSection(int Id)
        {
            var isDeleted = await _SectionService.DeleteSection(Id);
            if (!isDeleted)
            {
                return NotFound(new { message = "Section Not Found" });
            }
            return Ok(new { id=Id} );
        }

        [HttpPut("{Id:int}")]
        [ProducesResponseType(typeof(GetResponsSectionDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponsSectionDto>> UpdateSection(int Id, [FromForm] AddRequestSectiondto SectionDto)
        {
            var Section = await _SectionService.UpdateSection(Id,SectionDto);
            if (Section==null)
            {
                return NotFound(new { message = "Section Not Found" });
            }
            return Ok(Section);
        }
    }
}
