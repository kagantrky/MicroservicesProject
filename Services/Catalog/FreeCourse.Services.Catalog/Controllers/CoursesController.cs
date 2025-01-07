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
    internal class CoursesController : CustomBaseController
    {

        private readonly ICourseService _courseService;

        internal CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetAllAsync();
            //CreateActionResultInstance object result dönerken tüm durum kodlarını bize dönüyor tek tek yazmaya gerek yok
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(response);
        }

        //courses/4 gosteriyor. yazmazsak şu şekilde olacak courses?id=
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(response);
        }

        //üsttekide id aldığı için karışmaması için httpget değil route yazılıyor.
        //api/courses/getallbyuserid/4
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _courseService.GetAllByUserIdAsync(userId);
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(response);
        }


        //Create yaparken post yaptık.
        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
        {
            var response = await _courseService.CreateAsync(courseCreateDto);
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(response);
        }

        //update yaparken put yaptık
        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            var response = await _courseService.UpdateAsync(courseUpdateDto);
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(response);
        }

        //delete yaptığımızda id ile birlikte kullanılır.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteAsync(id);
            //normalde generic ama içindeki response da generic olduğu için tekrar bunu yazmaya gerek yok. 
            return CreateActionResultInstance(response);
        }


    }
}
