using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models.ViewModel
{
    public class NotificationsViewModel
    {
        public List<Notifications> Notifications { get; set; }

        public NotificationsViewModel()
        {

        }

        public NotificationsViewModel(List<Notifications> obj)
        {
            Notifications = obj;
        }

    }
}
