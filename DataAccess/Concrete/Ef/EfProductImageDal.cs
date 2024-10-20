using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
	public class EfProductImageDal(BaseProjectContext context) : BaseRepository<ProductImage, BaseProjectContext>(context), IProductImageDal
	{
		public List<ProductImageToProductsDto> GetAllProductsByFeatured()
		{
			BaseProjectContext baseContext = new BaseProjectContext();
			var result = from i in baseContext.ProductImages
						 where i.IsFutured == true
						 join p in baseContext.Products
						 on i.ProductId equals p.Id
						 select new ProductImageToProductsDto
						 {
							 ProductId = i.ProductId,
							 IsFeatured = p.IsFeatured,
							 PhotoUrl = i.PhotoUrl,
							 ProjectName = p.ProjectName,
							 ProjectType = p.ProjectType,
							 Description = p.Description,
							 
						 };
			return result.Where(p => p.IsFeatured == true).Take(4).ToList();

		}
	}
}
