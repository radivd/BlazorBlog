using BlazorBlog.Shared.Models;
using System.Collections.Generic;

namespace BlazorBlog.Server.Contracts
{
    public interface IPostData : IDataBase<Post>
    {
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetAllPublishedPosts();
        Post GetPostByUrl(string url);
        Post GetPublishedPostByUrl(string url);
        Post GetPostById(int id);
    }
}
