using Microsoft.AspNetCore.Mvc;
using RegistrationMicroservice.Models;
using RegistrationMicroservice.Services;
using System.Threading.Tasks;

namespace RegistrationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UserService _userService;

        public RegistrationController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.RegisterUser(user);
                    return Ok(new { message = "Registration successful!" });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
            return BadRequest(ModelState);
        }
    }
}