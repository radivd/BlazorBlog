using BlazorBlog.Shared.Models;
using System.Collections.Generic;

namespace BlazorBlog.Server.Contracts
{
    public interface IPostData : IDataBase<Post>
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPostByUrl(string url);
    }
}
