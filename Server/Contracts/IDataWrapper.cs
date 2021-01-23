namespace BlazorBlog.Server.Contracts
{
    public interface IDataWrapper
    {
        IUserData User { get; }
        IPostData Post { get; }
        void Save();
    }
}
