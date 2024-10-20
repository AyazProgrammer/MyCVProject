using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyCvProjectUI.Areas.DashBoard.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController( IAboutService aboutService)
        {

            _aboutService = aboutService;

        }
        public IActionResult AboutOperation()
        {
            return View();
        }
    }
}
