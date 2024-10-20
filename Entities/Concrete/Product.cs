using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:BaseEntity
    {
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }


        public string Description { get; set; }


        public bool IsFeatured { get; set; }

    }
}
