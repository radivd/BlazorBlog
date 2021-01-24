using BlazorBlog.Server.Contracts;
using BlazorBlog.Server.Models;
using BlazorBlog.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorBlog.Server.Data
{
    public class UserData : DataBase<User>, IUserData
    {
        public UserData(AMCDbContext amcDbContext) : base(amcDbContext)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(u => u.Username)
                .ToList();
        }
    }
}
