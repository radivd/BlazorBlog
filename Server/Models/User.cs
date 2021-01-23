using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorBlog.Server.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Author { get; set; }
        public string Api { get; set; }
    }
}
