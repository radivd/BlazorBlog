using BlazorBlog.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostByUrl(string url);
        void CreateNewPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int id);
    }
}
