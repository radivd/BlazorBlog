using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorBlog.Server.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Userid { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public int Author { get; set; }
        public DateTime? Created { get; set; }
        public DateTime Edited { get; set; }
        public bool Ispublished { get; set; }
    }
}
