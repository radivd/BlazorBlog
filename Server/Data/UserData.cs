using BlazorBlog.Server.Contracts;
using BlazorBlog.Server.Models;

namespace BlazorBlog.Server.Data
{
    public class UserData : DataBase<User>, IUserData
    {
        public UserData(AMCDbContext amcDbContext) : base(amcDbContext)
        {
        }
    }
}
