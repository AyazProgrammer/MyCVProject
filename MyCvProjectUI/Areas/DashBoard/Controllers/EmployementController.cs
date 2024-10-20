using Business.Abstract;
using Business.Validation;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCvProjectUI.ViewModels;

namespace MyCvProjectUI.Areas.DashBoard.Controllers
{
	[JwtTokenValidation]
	[Area("DashBoard")]
	public class EmployementController : Controller
    {
        private readonly ILogger<EmployementController> _logger;
        private readonly IEmployementService _employementService;



        public EmployementController(

               ILogger<EmployementController> logger,
               IEmployementService employementService

            )
        {
            _logger = logger;
            _employementService = employementService;

        }
        public IActionResult EmployementOperation()
        {
            EmployementVM vm = new()
            {
                Employments = _employementService.GetAllEmployment().Data,

            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult EmployementOperation(Employment employment, string actionType)
        {
            Console.WriteLine(employment.WorkName);
            try
            {
                if (actionType == "Add")
                {
                    _employementService.Add(employment);
                }

                else if (actionType == "Update")
                {

                    _employementService.Update(employment);
                }
                else if (actionType == "Delete")
                {
                    _employementService.Delete(employment.Id);
                }

                return RedirectToAction("EmployementOperation", "Employement");
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Error occurred while adding/updating/deleting certificate.");
                return NotFound();
            }
        }
    }
}
