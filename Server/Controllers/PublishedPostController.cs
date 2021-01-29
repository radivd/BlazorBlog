using BlazorBlog.Server.Contracts;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlazorBlog.Server.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PublishedPostController : ControllerBase
    {
        private IDataWrapper _data;
        private ILoggerManager _logger;

        public PublishedPostController(IDataWrapper dataWrapper, ILoggerManager logger)
        {
            _data = dataWrapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            try
            {
                var posts = _data.Post.GetAllPublishedPosts();
                if (posts != null)
                    _logger.LogInfo($"Got posts successfully");
                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went getting public posts: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{url}")]
        public ActionResult<Post> GetPostByUrl(string url)
        {
            var post = _data.Post.GetPublishedPostByUrl(url);
            if (post == null)
                return NotFound("CAN NOT FIND POST");

            return Ok(post);
        }
    }
}