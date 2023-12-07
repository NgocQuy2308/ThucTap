using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Entity;
using ThucTap.Iservice;
using ThucTap.Payloads.Requests;
using ThucTap.services;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }
        [HttpGet("get-all")]
        [Authorize(Roles = "admin")]
        public IActionResult Get([FromQuery] string? keyword,
                                 [FromQuery] int? Id = null)
        {
            var res = _userService.GetUsers(keyword,Id);
            return Ok(res);
        }
        [HttpDelete("{id})")] 
        public IActionResult Delete(int id)
        {
            _userService.DeleteUserRequest(id);
            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult update([FromForm]UpdateUserRequest request)
        {
            return Ok(_userService.UpdateUserRequest(request));
        }
    }
}
