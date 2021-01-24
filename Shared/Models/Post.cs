using System;
using System.Collections.Generic;

namespace BlazorBlog.Shared.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public bool IsPublished { get; set; }
    }
}
