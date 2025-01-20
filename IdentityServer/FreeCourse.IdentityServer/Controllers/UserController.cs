using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //kullanıcı kaydolabilmesi için
        //Username, mail, password ve city alanlarına ihtiyaç var
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDto signupDto)
        {
            var user = new ApplicationUser
            {
                //password burada yapmıyoruz. şifrenin hashlenmesi lazım. create yaparken yapılacak. 
                UserName = signupDto.UserName,
                Email = signupDto.Email,
                City = signupDto.City
            };
            var result = await _userManager.CreateAsync(user, signupDto.Password);
            if (!result.Succeeded) {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }
            return NoContent();
        }
    }
}
