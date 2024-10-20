using Business.Abstract;
using Business.Validation;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCvProjectUI.ViewModels;

namespace MyCvProjectUI.Areas.DashBoard.Controllers
{
	[JwtTokenValidation]
	[Area("DashBoard")]
    public class EducationController : Controller
    {
        private readonly ILogger<EducationController> _logger;
        private readonly IEducationService _educationService;

        public EducationController(

               ILogger<EducationController> logger,
               IEducationService educationService

            )
        {
            _logger = logger;
            _educationService = educationService;

        }
        public IActionResult EducationOperation()
        {
            EducationVM vm = new()
            {
                Educations = _educationService.GetAllEducation().Data,

            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult EducationOperation(Education education, string actionType)
        {
            try
            {
                if (actionType == "Add")
                {
                    _educationService.Add(education);
                }
                else if (actionType == "Update")
                {

                    _educationService.Update(education);
                }
                else if (actionType == "Delete")
                {
                    _educationService.Delete(education.Id);
                }

                return RedirectToAction("EducationOperation", "Education");
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Error occurred while adding/updating/deleting certificate.");
                return NotFound();
            }
        }
    }
}
