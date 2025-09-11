using Ecommerce.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }
        //[HttpGet]
        //public ActionResult Get()
        //{
        //    return Ok(_productService.GetProducts());
        //}

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {

            return Ok(await _productService.GetProductsAsync());
        }
        [HttpGet("{id}")]
    public async Task<ActionResult > GetProductByIdAsync(int id)
    {
            if (id <= 0) { return NotFound(); }
            return Ok(await _productService.GetProductAsync(id));

    }
        //[HttpGet("{id}")]
        //public  ActionResult GetProductById(int id)
        //{
        //    if (id == 0) { return NotFound(); }
        //    return Ok( _productService.GetProduct(id));
        //}


    }
}
