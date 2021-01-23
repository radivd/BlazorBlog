using BlazorBlog.Shared;
using System.Collections.Generic;

namespace BlazorBlog.Client.Services
{
    interface IPostService
    {
        List<Post> GetPosts();
        Post GetPostByUrl(string url);
    }
}
