using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillsService;


        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;

        }

        [HttpPost("addSkills")]
        public IActionResult Add(Skill skill)
        {

            var result = _skillsService.Add(skill);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


        [HttpPost("deleteSkills")]
        public IActionResult Delete(int id)
        {
            var result = _skillsService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetAllSkills")]
        public IActionResult GetAllEmployment()
        {
            var result = _skillsService.GetAllSkill();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
