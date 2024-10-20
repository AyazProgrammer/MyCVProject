using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class AboutImageToAboutsDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }


        public string Birthday { get; set; }

        public string PhotoUrl { get; set; }



        public string Adress { get; set; }
        public string Phone { get; set; }

        public string Linkedin { get; set; }
        public string Website { get; set; }
        public string Github { get; set; }
        public int AboutId { get; set; }

        public bool IsFeatured { get; set; }

        public int AboutImageId { get; set; }
    }
}
