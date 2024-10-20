using Business.Abstract;
using Business.Validation;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MyCvProjectUI.ViewModels;

namespace MyCvProjectUI.Areas.DashBoard.Controllers
{
	[JwtTokenValidation]
	[Area("DashBoard")]
	public class CertificateController : Controller
	{
		private readonly ILogger<CertificateController> _logger;
		private readonly ISertificateService _sertificateService;
		


		public CertificateController(
			   ILogger<CertificateController> logger,
			   ISertificateService sertificateService
			  
			)
		{
			_logger = logger;
			_sertificateService = sertificateService;

		}

		public IActionResult CertificateAdd()
		{
			CertificateVM vm = new()
			{
				Certificates = _sertificateService.GetAllCertificate().Data,

			};
			return View(vm);
		}
        [HttpPost]
        public IActionResult CertificateAdd(Certificate certificate, string actionType)
        {
            try
            {
                if (actionType == "Add")
                {
                    _sertificateService.Add(certificate);
                }
                else if (actionType == "Update")
                {
                    Console.WriteLine(certificate.CertificateName);
                    Console.WriteLine(certificate.Id);
                    Console.WriteLine(certificate.IsDeleted);
                    _sertificateService.Update(certificate);
                }
                else if (actionType == "Delete")
                {
                    _sertificateService.Delete(certificate.Id);
                }

                return RedirectToAction("CertificateAdd", "Certificate");
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Error occurred while adding/updating/deleting certificate.");
                return NotFound();
            }
        }
    }


}
