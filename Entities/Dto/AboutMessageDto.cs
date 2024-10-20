using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class AboutMessageDto:IDto
    {
        public int AboutId { get; set; }



        public int MessageId {  get; set; }


        public string Name { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }


        public string MessageInfo { get; set; }





    }
}
