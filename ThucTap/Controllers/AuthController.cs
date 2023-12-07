using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using ThucTap.Entity;
using ThucTap.Iservice;
using ThucTap.Payloads.Requests;
using ThucTap.services;

namespace ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public AuthController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterRequest([FromForm]RegisterRequest request)
        { 
            return Ok(await _registerService.AddAccountRequest(request));
        }
        [HttpPost("/api/auth/ConfirmCreateNewAccount")]
        public async Task<IActionResult> ConfirmCreateNewAccount([FromBody] Request_ConfirmCreateAccount request)
        {
            return Ok(await _registerService.ConfirmCreateNewAccount(request));
        }
        [HttpPost("Login")]
        public IActionResult LoginRequest(UserRequests request)
        { 
            return Ok(_registerService.LoginAccountRequest(request));
        }
        [HttpPost("ChangedPass")]
        public IActionResult ChangedPasss(ForgotPassRequest request)
        { 
            return Ok(_registerService.ForgotAccountRequest(request));
        }
    }
}
