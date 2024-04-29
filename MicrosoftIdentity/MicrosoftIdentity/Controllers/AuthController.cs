using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftIdentity.Dtos;
using MicrosoftIdentity.Services;
using static MicrosoftIdentity.Dtos.ServiceResponses;

namespace MicrosoftIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public AuthController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDtos userDTO)
        {
            var response = await _accountServices.CreateAccount(userDTO);
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            var response = await _accountServices.LoginAccount(loginDTO);
            return Ok(response);
        }

    }
}
