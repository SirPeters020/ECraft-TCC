using Ecraft.Api.Data.Repositories.Cryptography;
using Ecraft.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Data.Repositories.UnitsOfWork
{
    public class UnitOfWorkUser
    {

        private readonly ECraftContext _context;
        private readonly AesCryptographyService _crypto;
        public CryptoBaseRepository<User> UserRepo { get; set; }

        public UnitOfWorkUser(ECraftContext context, AesCryptographyService crypto)
        {
            _context = context;
            _crypto = crypto;
            UserRepo = new CryptoBaseRepository<User>(context, crypto);
        }


        public async Task CommitAssync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
