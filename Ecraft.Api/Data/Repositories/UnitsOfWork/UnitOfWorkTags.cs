using Ecraft.Api.Models;
using Ecraft.Api.Models.Join;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Data.Repositories.UnitsOfWork
{
    public class UnitOfWorkTags
    {
        private readonly ECraftContext _context;
        public BaseRepository<Tags> Tag { get; set; }
        public BaseRepository<TagPergunta> TagPergunta { get; set; }
        public BaseRepository<TagProjeto> TagProjeto { get; set; }
        public BaseRepository<TagReceita> TagReceita { get; set; }

        public UnitOfWorkTags(ECraftContext context)
        {
            _context = context;
            Tag = new BaseRepository<Tags>(context);
        }

        public async Task CommitAssync() => await _context.SaveChangesAsync();



    }
}
