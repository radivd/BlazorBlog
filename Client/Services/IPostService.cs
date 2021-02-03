using BlazorBlog.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();
        Task<List<Post>> GetAllPublishedPosts();
        Task<Post> GetPublishedPostByUrl(string url);
        Task<Post> GetPostByUrl(string url);
        Task<Post> CreateNewPostAsync(Post post);
        void UpdatePost(Post post);
        void DeletePost(int id);
    }
}
