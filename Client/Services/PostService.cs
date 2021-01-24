using BlazorBlog.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _http;

        public PostService(HttpClient http)
        {
            _http = http;
        }

        public Task<Post> GetPostByUrl(string url)
        {
            return _http.GetFromJsonAsync<Post>($"api/posts/{url}");
        }

        public Task<List<Post>> GetAllPosts()
        {
            return _http.GetFromJsonAsync<List<Post>>("api/posts/");
        }
    }
}