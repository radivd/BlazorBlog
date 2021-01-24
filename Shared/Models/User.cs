using System;

namespace BlazorBlog.Shared.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Author { get; set; }
        public string Api { get; set; }
    }
}
