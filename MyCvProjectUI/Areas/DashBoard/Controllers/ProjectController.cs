using Microsoft.AspNetCore.Mvc;

namespace MyCvProjectUI.Areas.DashBoard.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
