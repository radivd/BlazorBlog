using BlazorBlog.Server.Contracts;
using BlazorBlog.Server.Models;
using BlazorBlog.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBlog.Server.Data
{
    public class PostData : DataBase<Post>, IPostData
    {
        public PostData(AMCDbContext amcDbContext) : base(amcDbContext)
        {

        }

        public IEnumerable<Post> GetAllPosts() => FindAll().OrderBy(u => u.Created).ToList();
        public IEnumerable<Post> GetAllPublishedPosts() => FindByCondition(c => c.IsPublished == true).ToList();
        public Post GetPostByUrl(string url) => FindByCondition(c => c.Url == url).FirstOrDefault();
        public Post GetPublishedPostByUrl(string url) => FindByCondition(c => c.Url == url && c.IsPublished == true).FirstOrDefault();
        public Post GetPostById(int id) => FindByCondition(c => c.Id == id).FirstOrDefault();
    }
}
