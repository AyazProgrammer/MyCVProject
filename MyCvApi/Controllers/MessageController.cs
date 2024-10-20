using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
       

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
           
        }

       


        [HttpPost("deleteMessage")]
        public IActionResult Delete(int id)
        {
            var result = _messageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetAllMessage")]
        public IActionResult GetAllMessage()
        {
            var result = _messageService.GetAllMessage();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
