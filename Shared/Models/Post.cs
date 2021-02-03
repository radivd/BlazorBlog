using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Shared.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Required, StringLength(22)]
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        [Required, StringLength(40)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Edited { get; set; }
        public bool IsPublished { get; set; }
    }
}
