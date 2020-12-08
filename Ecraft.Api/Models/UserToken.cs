using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models
{
    public class UserToken
    {
        public User User { get; set; }
        public string Token { get; set; }

    }
}
