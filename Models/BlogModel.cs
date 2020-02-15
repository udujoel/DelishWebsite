using System;

namespace DelishWebsite.Models
{
    public class BlogModel
    {
        public int id { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}