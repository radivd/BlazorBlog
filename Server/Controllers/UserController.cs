using BlazorBlog.Server.Contracts;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlazorBlog.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IDataWrapper _data;
        private ILoggerManager _logger;

        public UserController(IDataWrapper dataWrapper, ILoggerManager logger)
        {
            _data = dataWrapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _data.User.GetAllUsers();
                if (users != null)
                    _logger.LogInfo($"Got users successfully");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went getting all users: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
