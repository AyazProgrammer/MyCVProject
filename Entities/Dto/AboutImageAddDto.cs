using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class AboutImageAddDto:IDto
    {
       
        public int AboutId { get; set; }

        public bool IsFeatured { get; set; }
        public IFormFile Photo { get; set; }
    }
}
