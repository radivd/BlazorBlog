using BlazorBlog.Server.Contracts;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IDataWrapper _data;
        private ILoggerManager _logger;

        public PostController(IDataWrapper dataWrapper, ILoggerManager logger)
        {
            _data = dataWrapper;
            _logger = logger;
        }
        
        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            try
            {
                var posts = _data.Post.GetAllPosts();
                if (posts != null)
                    _logger.LogInfo($"Got posts successfully");
                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went getting all posts: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{url}")]
        public ActionResult<Post> GetPostByUrl(string url)
        {
            var post = _data.Post.GetPostByUrl(url);
            if (post == null)
                return NotFound("CAN NOT FIND POST");

            return Ok(post);
        }

        [HttpPost]
        public IActionResult CreateNewPost([FromBody] Post post)
        {
            try
            {
                _data.Post.Create(post);
                _data.Save();

                return Created("Post", post);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong creating post: {ex.InnerException}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public IActionResult UpdatePost([FromBody] Post post)
        {
            try
            {
                if (post == null)
                {
                    _logger.LogError("Post object sent from client is null.");
                    return BadRequest("Post object from client is empty");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid post model object sent from client.");
                    return BadRequest("Invalid post model object");
                }

                var oldPost = _data.Post.GetPostById(post.Id);

                if (oldPost == null)
                {
                    _logger.LogError($"Post with id: {post.Id}, was not found.");
                    return NotFound();
                }

                _data.Post.Update(post);
                _data.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong updating post: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            try
            {
                var post = _data.Post.GetPostById(id);

                if (post == null)
                {
                    _logger.LogError($"Post with id: {id}, was not found in");
                    return NotFound();
                }

                _data.Post.Delete(post);
                _data.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside trying to delete post: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}