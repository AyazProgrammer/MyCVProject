using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
	public class ProductImageToProductsDto : IDto
	{
		public string ProjectName { get; set; }
        public string ProjectType { get; set; }


        public string Description { get; set; }
		public int ProductId { get; set; }
		
		public bool IsFeatured { get; set; }
        public string PhotoUrl { get; set; }
        public int ProductImageId { get; set; }
    }
}
