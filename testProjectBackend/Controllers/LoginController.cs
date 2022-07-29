using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using testProjectBackend.DTO;
using testProjectBackend.Services;

namespace testProjectBackend.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("auth")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (model is null)
                return BadRequest("User is not found");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var token = await _userService.AuthenticateAsync(model);
            var response = new
            {
                StatusCode = 200,
                AccessToken = token
            };
            return Ok(response);
        }
    }
}