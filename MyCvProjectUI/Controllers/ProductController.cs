using Business.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace MyCvProjectUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductImageService _productImageService;
		private readonly IProductService _productService;

		public ProductController(IProductService productService, IProductImageService productImageService)
		{
			_productService = productService;
			_productImageService = productImageService;
		}

		public IActionResult Index()
		{
			return View();
		}

		
	}
}
