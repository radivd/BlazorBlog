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

        public IEnumerable<Post> GetAllPosts()
        {
            return FindAll()
                .OrderBy(u => u.Created)
                .ToList();
        }

        public Post GetPostByUrl(string url)
        {
            return FindByCondition(c => c.Url == url).FirstOrDefault();
        }
    }
}
