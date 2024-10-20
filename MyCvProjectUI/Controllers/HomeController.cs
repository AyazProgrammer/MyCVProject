using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using MyCvProjectUI.ViewModels;
using MyCvProjectUI.Models;
using System.Diagnostics;
using Entities.Concrete;

namespace MyCvProjectUI.Controllers
{
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


      
        public HomeController(

            ILogger<HomeController> logger,
            IAboutService aboutService,
            ISertificateService sertificateService,
            IEducationService educationService,
            IEmployementService employementService,
            ISkillsService skillsService
,
            IMessageService messageService

,
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
            
        }

        public IActionResult Index()
        {
            ProfileVM vm = new()
            {

                Abouts = _aboutService.GetAllAbout().Data,
                Certificates= _sertificateService.GetAllCertificate().Data,
                Educations = _educationService.GetAllEducation().Data,
                Employments =_employementService.GetAllEmployment().Data,
                Skills = _skillsService.GetAllSkill().Data,
                Products = _productImageService.GetAllProductImagesByFeatured().Data,
                Aboutss = _aboutImageService.GetAllAboutImagesByFeatured().Data,
                Message = _messageService.GetAllMessage().Data, 
                AboutsByImage = _aboutImageService.GetAllAboutByImages().Data
                
                
            };
            return View(vm);
            
        }
        [HttpPost]
        public IActionResult Index(Message message)
        {
            try
            {
                Random random = new Random();
                message.AboutId = random.Next(1, 100);
              

                _messageService.Add(message);
               
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");

            }

        }

       

        public IActionResult Detail()
        {

            return View();
        }
        public IActionResult Add()
        {
            ProfileVM vm = new()
            {

                Abouts = _aboutService.GetAllAbout().Data,
                Certificates = _sertificateService.GetAllCertificate().Data,
                Educations = _educationService.GetAllEducation().Data,
                Employments = _employementService.GetAllEmployment().Data,
                Skills = _skillsService.GetAllSkill().Data,
                Products = _productImageService.GetAllProductImagesByFeatured().Data,
                Aboutss = _aboutImageService.GetAllAboutImagesByFeatured().Data

            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductImageAddDto productImage)
        {
            try
            {
               _productImageService.AddProductImage(productImage);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");

            }
        }
        public IActionResult ProfilePhoto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProfilePhoto(AboutImageAddDto aboutImageAddDto)
        {
            try
            {
                _aboutImageService.AddAboutImage(aboutImageAddDto);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
