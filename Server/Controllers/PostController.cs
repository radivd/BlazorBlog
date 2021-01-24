using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public List<Post> Posts { get; set; } = new List<Post>()
        {
            new Post { Url="first-post", Title = "Blazor Blog Post 1 test", Description="This is the first test post", Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur ac sem et nulla tincidunt hendrerit ac a odio. Sed sed elementum nisi, vitae pretium leo. Aenean viverra arcu vel quam luctus egestas. Nunc rutrum pulvinar elementum. Proin neque odio, blandit quis molestie a, posuere sed elit. Sed eu quam in ligula semper volutpat. Fusce vel diam turpis. Suspendisse in sollicitudin arcu. Maecenas lobortis ligula sed leo finibus semper." },
            new Post { Url="second-post", Title = "Pust number two test", Description="This is the second test post", Content="Etiam eget porta metus. Aenean ultrices vitae magna ut dictum. Sed congue ante quis viverra consequat. In eu turpis et ipsum porta bibendum a vel velit. Nam pharetra odio nec facilisis placerat. Suspendisse ac vestibulum tortor. Maecenas convallis mauris libero, in finibus arcu pharetra ac. Integer cursus sed eros quis suscipit. Mauris vitae consequat enim. Fusce volutpat erat vitae eros aliquet malesuada. Aliquam ac nibh tellus. Sed laoreet quam a dolor sodales, id ornare eros fermentum." }
        };

        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            return Ok(Posts);
        }

        [HttpGet("{url}")]
        public ActionResult<Post> GetPost(string url)
        {
            var post = Posts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null)
                return NotFound("CAN NOT FIND POST");

            return Ok(post);
        }
    }
}
