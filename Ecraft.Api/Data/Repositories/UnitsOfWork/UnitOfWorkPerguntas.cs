using Ecraft.Api.Models;
using Ecraft.Api.Models.Join;
using Ecraft.Api.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Data.Repositories.UnitsOfWork
{
    public class UnitOfWorkPerguntas
    {

        private readonly ECraftContext _context;
        public BaseRepository<Perguntas> Perguntas { get; set; }
        public BaseRepository<TagPergunta> TagPerg { get; set; }
        public BaseRepository<Tags> Tag { get; set; }
        private BaseRepository<Imagens> Img { get; set; }
        public BaseRepository<Respostas> Respostas { get; set; }

        public UnitOfWorkPerguntas(ECraftContext context)
        {
            _context = context;
            Perguntas = new BaseRepository<Perguntas>(context);
            TagPerg = new BaseRepository<TagPergunta>(context);
            Tag = new BaseRepository<Tags>(context);
            Img = new BaseRepository<Imagens>(context);
            Respostas = new BaseRepository<Respostas>(context);
        }


        //public async Task<List<Perguntas>> GetAll() => (List<Perguntas>)await Perguntas.GetAsync();

        public async Task<Perguntas> GetById(int id)
        {
            var perguntas = await Perguntas.GetByIdAssync(id);
            var imgs = await Img.GetAsync(x => x.ReceitasId == perguntas.Id);
            var respostas = await Respostas.GetAsync(x => x.PerguntaId == perguntas.Id);
            var tagProj = await TagPerg.GetAsync(x => x.PerguntasId == perguntas.Id);
            perguntas.Imagens = imgs;
            perguntas.Respostas = respostas;
            perguntas.Tag = tagProj;
            return perguntas;
        }

        //public Task Update(Perguntas obj) => Perguntas.Update(obj);

        //public Task Create(Perguntas obj) => Perguntas.Insert(obj);

        //public async Task Delete(int id) => await Perguntas.DeleteAsync(id);

        public async Task Curtir(int id)
        {
            var perguntas = await Perguntas.GetByIdAssync(id);
            perguntas.Likes++;
            _context.Update(perguntas);
            await _context.SaveChangesAsync();
        }

        public async Task Descurtir(int id)
        {
            var perguntas = await Perguntas.GetByIdAssync(id);
            perguntas.Unlikes++;
            await _context.SaveChangesAsync();
        }

        public async Task Acessos(Receitas obj)
        {
            obj.Access++;
            await _context.SaveChangesAsync();
        }

        public async Task CommitAssync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
