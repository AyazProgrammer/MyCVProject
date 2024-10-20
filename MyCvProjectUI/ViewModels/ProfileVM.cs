
using Entities.Concrete;
using Entities.Dto;

namespace MyCvProjectUI.ViewModels
{
	public class ProfileVM
	{
        //  public List<ProductImageToProductsDto> Products { get; set; }

        //public List<ProductImageToProductsDto> Products { get; set; }
        public List<About> Abouts { get; set; }
        public List<Certificate> Certificates { get; set; }
        public List<Education> Educations { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProductImageToProductsDto> Products { get; set; }
        public List<Product> ProductsAll { get; set; }
        public List<Employment> Employments { get; set; }
        public List<AboutImageToAboutsDto> Aboutss { get; set; }
        public List<AboutImageToAboutsDto> AboutsByImage { get; set; }
        public List<Message> Message { get; set; }


    }
}
