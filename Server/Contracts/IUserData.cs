using BlazorBlog.Shared.Models;
using System.Collections.Generic;

namespace BlazorBlog.Server.Contracts
{
    public interface IUserData : IDataBase<User>
    {
        IEnumerable<User> GetAllUsers();
    }
}