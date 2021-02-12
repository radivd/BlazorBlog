using BlazorBlog.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
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
        Task<string> UploadImageAsync(MultipartFormDataContent content);
        Task<Post> UpdatePostAsync(Post post);
        Task<Post> DeletePostAsync(string url);
    }
}
