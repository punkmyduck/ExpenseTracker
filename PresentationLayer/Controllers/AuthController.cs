using ExpenseTracker.ApplicationLayer.DTO.Auth;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ExpenseTracker.PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly ILoginUserService _loginUserService;
        public AuthController(IRegisterUserService registerUserService, ILoginUserService loginUserService)
        {
            _registerUserService = registerUserService;
            _loginUserService = loginUserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest registerRequest)
        {
            var result = await _registerUserService.ExecuteAsync(registerRequest);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginUserRequest loginRequest)
        {
            var result = await _loginUserService.ExecuteAsync(loginRequest);

            Response.Cookies.Append("OOohMyGooOOad", result.Token);

            return Ok(result);
        }
    }
}
