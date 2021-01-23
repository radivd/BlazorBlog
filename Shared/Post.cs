using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Shared
{
    public class Post
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public DateTime TimeEdited { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = true;
    }
}
