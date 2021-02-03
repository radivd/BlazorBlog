using System;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _http;
        private readonly IAccessTokenProvider _tokenProvider;

        public PostService(HttpClient http, IAccessTokenProvider tokenProvider)
        {
            _http = http;
            _tokenProvider = tokenProvider;
        }

        public Task<List<Post>> GetAllPublishedPosts() => _http.GetFromJsonAsync<List<Post>>("api/post/");
        public Task<Post> GetPublishedPostByUrl(string url) => _http.GetFromJsonAsync<Post>($"api/post/{url}");

        public async Task<List<Post>> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/post/editor"))
            {
                var tokenResult = await _tokenProvider.RequestAccessToken();

                if (tokenResult.TryGetToken(out var token))
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                    var response = await _http.SendAsync(requestMessage);
                    posts = await response.Content.ReadFromJsonAsync<List<Post>>();
                }
            }
            return posts;
        }

        public async Task<Post> GetPostByUrl(string url)
        {
            Post post;
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/post/editor/{url}"))
            {
                var tokenResult = await _tokenProvider.RequestAccessToken();

                if (tokenResult.TryGetToken(out var token))
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                    var response = await _http.SendAsync(requestMessage);
                    post = await response.Content.ReadFromJsonAsync<Post>();
                    return post;
                }
            }
            return null;
        }

        public async Task<Post> CreateNewPostAsync(Post post)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/post/editor/"))
            {
                var tokenResult = await _tokenProvider.RequestAccessToken();

                if (tokenResult.TryGetToken(out var token))
                {
                    var json = JsonConvert.SerializeObject(post);
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                    requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _http.SendAsync(requestMessage);
                    return await response.Content.ReadFromJsonAsync<Post>();
                }
            }
            return null;
        }
        
        public async Task<string> UploadImageAsync(MultipartFormDataContent content)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/upload"))
            {
                var tokenResult = await _tokenProvider.RequestAccessToken();

                if (tokenResult.TryGetToken(out var token))
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                    requestMessage.Content = content;
                    var response = await _http.SendAsync(requestMessage);
                    var result = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                        throw new ApplicationException(result);

                    return Path.Combine("", result);
                }
            }
            return null;
        }

        public void UpdatePost(Post post) => _http.PutAsJsonAsync("api/post/", post);
        public void DeletePost(int id) => _http.DeleteAsync($"api/post/{id}");
    }
}