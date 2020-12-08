using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models.ViewModel
{
    public class FeedViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime Date { get; set; }
        public User Author { get; set; }
        public string[] Tags { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }

        User user = new User()
        {
            Id = 1,
            Name = "Pedro Augusto",
            Avatar = "/images/avatar/maxresdefault.jpg"
        };

        string[] testeTags = { " croche ", " bordado ", " croche-tunisiano ", " pintura " };

        public FeedViewModel()
        {
            
        }


        public List<FeedViewModel> ItensTeste()
        {
            var feed1 = new FeedViewModel()
            {
                Id = 1,
                Title = "COMO BORDAR PERSONAGENS DE DESENHOS | Dicas e Truques #02",
                Slug = "como-bordar-personagens-de-desenhos",
                Date = DateTime.Today,
                Author = user,
                Tags = testeTags,
                Image = "/images/posts/plantinha.jpeg",
                Likes = 30,
                Comments = 10
            };
            var feed2 = new FeedViewModel()
            {
                Id = 2,
                Title = "COMO FAZER CROCHE TUNISIANO | Tips & Tricks - croche-tunisiano #01",
                Slug = "como-fazer-croche-tunisiano",
                Date = DateTime.Today,
                Author = user,
                Tags = testeTags,
                Image = "/images/posts/cachecol.jpeg",
                Likes = 27,
                Comments = 5
            };
            var feedList = new List<FeedViewModel>();
            feedList.Add(feed1);
            feedList.Add(feed2);
            return feedList;
        }

    }
}
