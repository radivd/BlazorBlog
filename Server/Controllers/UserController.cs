using BlazorBlog.Server.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlazorBlog.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IDataWrapper _data;

        public UserController(IDataWrapper dataWrapper)
        {
            _data = dataWrapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _data.User.GetAllUsers();
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
