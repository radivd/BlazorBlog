using BlazorBlog.Server.Contracts;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlazorBlog.Server.Controllers
{
    [ApiController]
    [Route("api/post/editor")]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IDataWrapper _data;

        public PostController(IDataWrapper dataWrapper)
        {
            _data = dataWrapper;
        }
        
        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            try
            {
                var posts = _data.Post.GetAllPosts();
                return Ok(posts);
            }
            catch
            {
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
            catch
            {
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
                    return BadRequest("Post object from client is empty");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid post model object");
                }

                var oldPost = _data.Post.GetPostById(post.Id);

                if (oldPost == null)
                {
                    return NotFound();
                }

                _data.Post.Update(post);
                _data.Save();

                return Created("Post", post);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{url}")]
        public IActionResult DeletePost(string url)
        {
            try
            {
                var post = _data.Post.GetPostByUrl(url);

                if (post == null)
                {
                    return NotFound();
                }

                _data.Post.Delete(post);
                _data.Save();

                return Accepted();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}