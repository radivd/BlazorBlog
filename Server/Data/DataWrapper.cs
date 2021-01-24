using BlazorBlog.Server.Contracts;
using BlazorBlog.Server.Models;

namespace BlazorBlog.Server.Data
{
    public class DataWrapper : IDataWrapper
    {
        private readonly AMCDbContext _amcdbContext;
        private IUserData _user;
        private IPostData _post;

        public DataWrapper(AMCDbContext amcdbContext)
        {
            _amcdbContext = amcdbContext;
        }

        public IUserData User
        {
            get
            {
                if (_user == null)
                    _user = new UserData(_amcdbContext);

                return _user;
            }
        }

        public IPostData Post
        {
            get
            {
                if (_post == null)
                    _post = new PostData(_amcdbContext);

                return _post;
            }
        }

        public void Save()
        {
            _amcdbContext.SaveChanges();
        }
    }
}
