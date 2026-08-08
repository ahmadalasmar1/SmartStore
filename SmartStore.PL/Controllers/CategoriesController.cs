using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmartStore.BLL.Services;
using SmartStore.DAL.Dto.Request;

namespace SmartStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);

        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryRequestDto request)
        {
            var result = await _categoryService.AddCategoryAsync(request);

            return CreatedAtAction(nameof(GetById), new {id =result.Id},result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CategoryRequestDto request)
        {
            //سميناه result عشان برجع bool
            var result = await _categoryService.UpdateCategoryAsync(id, request);
            if (!result)
            {
                return NotFound();
                //لما الـService ترجع false في الـUpdate، السبب عندنا غالبًا إن الـCategory مش موجودة
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        



    }
}
