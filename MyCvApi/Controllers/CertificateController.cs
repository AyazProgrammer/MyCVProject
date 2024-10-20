using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ISertificateService _sertificateService;
       

        public CertificateController(ISertificateService sertificateService)
        {
            _sertificateService = sertificateService;
           
        }

        [HttpPost("addCertificate")]
        public IActionResult Add(Certificate certificate)
        {

            var result = _sertificateService.Add(certificate);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


        [HttpPost("deleteCertificate")]
        public IActionResult Delete(int id)
        {
            var result = _sertificateService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetAllCertificate")]
        public IActionResult GetAllCertificate()
        {
            var result = _sertificateService.GetAllCertificate();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}

