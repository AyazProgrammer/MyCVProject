using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployementController : ControllerBase
    {
        private readonly IEmployementService _employementService;


        public EmployementController(IEmployementService employementService)
        {
            _employementService = employementService;

        }

        [HttpPost("addEmployement")]
        public IActionResult Add(Employment employement)
        {

            var result = _employementService.Add(employement);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


        [HttpPost("deleteEmployement")]
        public IActionResult Delete(int id)
        {
            var result = _employementService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetAllEmployement")]
        public IActionResult GetAllEmployment()
        {
            var result = _employementService.GetAllEmployment();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
