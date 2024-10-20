using Business.Abstract;
using Business.Validation;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCvProjectUI.ViewModels;

namespace MyCvProjectUI.Areas.DashBoard.Controllers
{
	[JwtTokenValidation]
	[Area("DashBoard")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAboutService _aboutService;
        private readonly ISertificateService _sertificateService;
        private readonly IEducationService _educationService;
        private readonly IEmployementService _employementService;
        private readonly ISkillsService _skillsService;
        private readonly IMessageService _messageService;
        private readonly IProductImageService _productImageService;
        private readonly IAboutImageService _aboutImageService;
        private readonly IProductService _productService;




        public HomeController(

            ILogger<HomeController> logger,
            IAboutService aboutService,
            ISertificateService sertificateService,
            IEducationService educationService,
            IEmployementService employementService,
            ISkillsService skillsService
,
            IMessageService messageService
,           IProductService productService,
            IProductImageService productImageService,
            IAboutImageService aboutImageService
            )
        {
            _aboutService = aboutService;
            _educationService = educationService;
            _employementService = employementService;
            _skillsService = skillsService;
           
            _logger = logger;
            _aboutService = aboutService;
            _sertificateService = sertificateService;
            _messageService = messageService;
            _productImageService = productImageService;
            _aboutImageService = aboutImageService;
            _productService = productService;
            

        }

		[JwtTokenValidation]
		public IActionResult Index()
		{
            
			//var token = Request.Cookies["jwt"];
			////Response.Cookies.Delete("jwt");

			//if (string.IsNullOrEmpty(token))
			//{
			//	return RedirectToAction("Login", "Account"); 
			//}

			//// Token'in süresini kontrol et
			//var tokenExpiration = TokenTimeCheck.GetTokenExpiration(token); 

			//if (tokenExpiration == null || tokenExpiration < DateTime.UtcNow) 
			//{
				
				
			//	return RedirectToAction("Login", "Account"); 
			//}

			ProfileVM vm = new()
			{
				Abouts = _aboutService.GetAllAbout().Data,
				Certificates = _sertificateService.GetAllCertificate().Data,
				Educations = _educationService.GetAllEducation().Data,
				Employments = _employementService.GetAllEmployment().Data,
				Skills = _skillsService.GetAllSkill().Data,
				Products = _productImageService.GetAllProductImagesByFeatured().Data,
				Aboutss = _aboutImageService.GetAllAboutImagesByFeatured().Data,
				Message = _messageService.GetAllMessage().Data,
				AboutsByImage = _aboutImageService.GetAllAboutByImages().Data,
				ProductsAll = _productService.GetAllProducts().Data,
			};

			return View(vm);
		}


		[HttpPost]
        public IActionResult Index(int id)
        {

            try
            {
              
                _messageService.Delete(id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return NotFound();

            }
        }

       






    }
}
