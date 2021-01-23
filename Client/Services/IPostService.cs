using BlazorBlog.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Services
{
    interface IPostService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostByUrl(string url);
    }
}
