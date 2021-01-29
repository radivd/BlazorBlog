using BlazorBlog.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllEditorPosts();
        Task<List<Post>> GetAllPublishedPosts();
        Task<Post> GetPublishedPostByUrl(string url);
        Task<Post> GetEditorPostByUrl(string url);
        Task<Post> CreateNewPostAsync(Post post);
        void UpdatePost(Post post);
        void DeletePost(int id);
    }
}
