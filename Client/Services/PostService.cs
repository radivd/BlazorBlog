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

        public PostService(HttpClient http) => _http = http;

        public Task<Post> GetPostByUrl(string url) => _http.GetFromJsonAsync<Post>($"api/post/{url}");
        public Task<List<Post>> GetAllPosts() => _http.GetFromJsonAsync<List<Post>>("api/post/");

        public async Task<Post> CreateNewPostAsync(Post post)
        {
            var result = await _http.PostAsJsonAsync("api/post/", post);
            return result.Content.ReadFromJsonAsync<Post>().Result;
        }

        public void UpdatePost(Post post) => _http.PutAsJsonAsync("api/post/", post);
        public void DeletePost(int id) => _http.DeleteAsync($"api/post/{id}");
    }
}