using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models.ViewModel
{
    //classe temporaria
    public class UserViewModel
    {
        public int Id { get; set; } = 1;
        public string Username { get; set; } = "Pedro Augusto";
        public string Email { get; set; } = "pedroaugusto";
        public string accessToken { get; set; } = "34hui5ui3e4h6tu";
        public string Avatar { get; set; } = "/images/avatar/maxresdefault.jpg";
        public string JoinedIn { get; set; } = "06 de janeiro, 2020";
        public string Work { get; set; } = "Developer";
        public string TotalPost { get; set; } = "388";
    }
}
