using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models.ViewModel
{
    public class PostsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime Date { get; set; }
        public User Author { get; set; }
        public string MarkdownText { get; set; }
        public string Tags { get; set; }
        public string Image { get; set; }
        public int Like { get; set; }
        public int Comments { get; set; }

    }
}
