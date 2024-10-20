using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;


        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;

        }

        [HttpPost("addEducation")]
        public IActionResult Add(Education education)
        {

            var result = _educationService.Add(education);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


        [HttpPost("deleteCertificate")]
        public IActionResult Delete(int id)
        {
            var result = _educationService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetAllEducation")]
        public IActionResult GetAllEducation()
        {
            var result = _educationService.GetAllEducation();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
