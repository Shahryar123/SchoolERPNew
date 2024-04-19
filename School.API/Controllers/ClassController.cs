using Azure;
using DemoAttendenceFeature.Dtos.Admission;
using DemoAttendenceFeature.Dtos.Class;
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
    public class ClassController : ControllerBase
    {
        private readonly ClassService _ClassService;

        public ClassController(ClassService ClassService)
        {
            _ClassService = ClassService;
        }

        [HttpGet("{Id:int}", Name = "GetClass")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetResponseClassDto),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseClassDto>> GetClass(int Id)
        {
            try
            {
                var Class = await _ClassService.GetClassById(Id);
                if (Class == null)
                {
                    return NotFound(new { message = "Class Not Found" });
                }
                return Ok(Class);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
            
        }


        [HttpPost]
        [ProducesResponseType(typeof(GetResponseClassDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseClassDto>> CreateClass([FromBody]AddRequestClassdto ClassDto)
        {
            try
            {
                var Class = await _ClassService.CreateClass(ClassDto);
                if (Class == null)
                {
                    return BadRequest(new { message = "Failed to Create Class" });
                }
                return Ok(Class);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new {message= ex.Message });
            }

        }


        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<GetResponseClassDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseClassDto>> GetClasss()
        {

            try
            {
                var Classs = await _ClassService.GetAllClasss();
                if (Classs == null)
                {
                    return NotFound(new { message = "No Class Found" });
                }
                return Ok(Classs);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<string>> DeleteClass(int Id)
        {
            var isDeleted = await _ClassService.DeleteClass(Id);
            if (!isDeleted)
            {
                return NotFound(new { message = "Class Not Found" });
            }
            return Ok(new { Classid=Id} );
        }

        [HttpPut("{Id:int}")]
        [ProducesResponseType(typeof(GetResponseClassDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetResponseClassDto>> UpdateClass(int Id, [FromForm] AddRequestClassdto ClassDto)
        {
            var Class = await _ClassService.UpdateClass(Id,ClassDto);
            if (Class==null)
            {
                return NotFound(new { message = "Class Not Found" });
            }
            return Ok(Class);
        }
    }
}
