using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models
{
    public class Notifications
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public Notifications()
        {

        }

        public List<Notifications> NotificationsTeste()
        {
            var notificationReview = new Notifications()
            {
                Id = "909v8svsed7H9dfb",
                Title = "Novo avaliaçãor recebida",
                Description = "você recebeu 1 nova avaliação",
                Type = "review",
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            };

            var notificationComment = new Notifications()
            {
                Id = "123map3e34ekn55",
                Title = "Novo comentario recebida",
                Description = "você recebeu 1 novo comentario",
                Type = "new_comment",
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            };

            var notificationLike = new Notifications()
            {
                Id = "123map3e34ekn55",
                Title = "Novo comentario recebida",
                Description = "você recebeu 1 novo comentario",
                Type = "new_comment",
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            };

            var notificationConnection = new Notifications()
            {
                Id = "l35ubviu23iu5ub23",
                Title = "Novos seguidores",
                Description = "2 usuarios começaram a seguir você",
                Type = "connection",
                CreatedAt = DateTime.UtcNow.AddDays(-4)
            };
            var notificationsList = new List<Notifications>();
            notificationsList.Add(notificationReview);
            notificationsList.Add(notificationComment);
            notificationsList.Add(notificationLike);
            notificationsList.Add(notificationConnection);

            return notificationsList;

        }

    }
}
