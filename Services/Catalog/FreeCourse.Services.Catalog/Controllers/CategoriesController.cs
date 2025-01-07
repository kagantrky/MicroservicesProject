using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            //CreateActionResultInstance object result dönerken tüm durum kodlarını bize dönüyor tek tek yazmaya gerek yok
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var response = await _categoryService.CreateAsync(categoryDto);
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(response);
        }


    }
}
