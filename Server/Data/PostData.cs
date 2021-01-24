using BlazorBlog.Server.Contracts;
using BlazorBlog.Server.Models;
using BlazorBlog.Shared.Models;

namespace BlazorBlog.Server.Data
{
    public class PostData : DataBase<Post>, IPostData
    {
        public PostData(AMCDbContext amcDbContext) : base(amcDbContext)
        {
        }
    }
}
