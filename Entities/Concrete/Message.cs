using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Message:BaseEntity
    {

        public int AboutId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }


        public string MessageInfo{ get; set; }

        


    }
}
