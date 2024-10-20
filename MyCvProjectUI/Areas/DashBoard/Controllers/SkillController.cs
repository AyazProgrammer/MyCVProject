using Business.Abstract;
using Business.Validation;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCvProjectUI.ViewModels;

namespace MyCvProjectUI.Areas.DashBoard.Controllers
{
	[JwtTokenValidation]
	[Area("DashBoard")]
    public class SkillController : Controller
    {
        private readonly ILogger<SkillController> _logger;
        private readonly ISkillsService _skillsService;



        public SkillController(

               ILogger<SkillController> logger,
               ISkillsService skillsService

            )
        {
            _logger = logger;
            _skillsService = skillsService;

        }
        public IActionResult SkillOperation()
        {
            SkillVM vm = new()
            {
                Skills = _skillsService.GetAllSkill().Data,

            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult SkillOperation(Skill skill, string actionType)
        {
            try
            {
                if (actionType == "Add")
                {
                    _skillsService.Add(skill);
                }

                else if (actionType == "Update")
                {

                    _skillsService.Update(skill);
                }
                else if (actionType == "Delete")
                {
                    _skillsService.Delete(skill.Id);
                }

                return RedirectToAction("SkillOperation", "Skill");
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Error occurred while adding/updating/deleting certificate.");
                return NotFound();
            }
        }
    }
}
