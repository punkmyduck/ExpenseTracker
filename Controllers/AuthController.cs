using ExpenseTracker.DomainLayer.Auth;
using ExpenseTracker.DomainLayer.Auth.DTO;
using ExpenseTracker.DomainLayer.Auth.Validation;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterUserService _registerUserService;
        public AuthController(IRegisterUserService registerUserService)
        {
            _registerUserService = registerUserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest registerRequest)
        {
            var result = await _registerUserService.ExecuteAsync(registerRequest);
            return Ok(result);
        }
    }
}
