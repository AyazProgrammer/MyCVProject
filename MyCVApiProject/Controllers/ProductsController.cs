using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCvApiProjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;

        public ProductsController(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        [HttpGet("AddProduct")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProducts();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpPost("addProduct")]
        public IActionResult Add(ProductImageAddDto productImageAddDto)
        {
            Product product = new()
            {
                Id = productImageAddDto.ProductId,
                Description = productImageAddDto.Description,
                IsFeatured = productImageAddDto.IsFeatured,
                ProjectName = productImageAddDto.Name,
                ProjectType = productImageAddDto.ProductType,

            };

            var result = _productService.Add(product);
            var imageResult = _productImageService.AddProductImage(productImageAddDto);
            if (result.Success && imageResult.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
