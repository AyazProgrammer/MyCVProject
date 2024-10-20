using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IAboutImageService _aboutImageService;

        public AboutController(IAboutService aboutService, IAboutImageService aboutImageService)
        {
            _aboutService = aboutService;
            _aboutImageService = aboutImageService;
        }

        [HttpPost("addAbout")]
        public IActionResult Add(About about)
        {

            var result = _aboutService.Add(about);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
       

        [HttpPost("deleteAbout")]
        public IActionResult Delete(int id)
        {
            var result = _aboutService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetAllAbout")]
        public IActionResult GetAllProducts()
        {
            var result = _aboutService.GetAllAbout();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
