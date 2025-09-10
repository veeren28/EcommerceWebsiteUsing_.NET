using Ecommerce.core;
using Ecommerce.service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult>  Get()
        {
         
            return Ok(await _categoryService.GetCategory());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetCategory(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryModel Category)
        {
            return Ok(await _categoryService.CreateCategory(Category));
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult>  Put(int id, [FromBody] CategoryModel cat)
        {
            var updateCategory = await _categoryService.GetCategory(id);

            updateCategory.Name = cat.Name;
           
            return Ok(await _categoryService.UpdateCategory(updateCategory));

        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _categoryService.DeleteCategory(id));
        }
    }
}
