using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCvApi.Controllers
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


        [HttpPost("addProduct")]
        public IActionResult Add(Product product)
        {
   
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpPost("addProductImage")]
        public IActionResult Add(ProductImageAddDto productImage)
        {

            var result = _productImageService.AddProductImage(productImage);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("deleteProduct")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetAllProduct")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProducts();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }



    }
}
