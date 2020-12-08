using Ecraft.Api.Models;
using Ecraft.Api.Models.Join;
using Ecraft.Api.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Data.Repositories.UnitsOfWork
{
    public class UnitOfWorkReceitas
    {
        private readonly ECraftContext _context;
        public BaseRepository<Receitas> Receitas { get; set; }
        public BaseRepository<TagReceita> TagProj { get; set; }
        public BaseRepository<Tags> Tags { get; set; }
        private BaseRepository<Imagens> Img { get; set; }
        private BaseRepository<Respostas> Resp { get; set; }

        public UnitOfWorkReceitas(ECraftContext context)
        {
            _context = context;
            Receitas = new BaseRepository<Receitas>(context);
            TagProj = new BaseRepository<TagReceita>(context);
            Tags = new BaseRepository<Tags>(context);
            Img = new BaseRepository<Imagens>(context);
            Resp = new BaseRepository<Respostas>(context);
        }

        //public async Task<List<Receitas>> GetAll() => (List<Receitas>) await Receitas.GetAsync();

        public async Task<Receitas> GetById(int id)
        {
            var receitas = await Receitas.GetByIdAssync(id);
            var imgs = await Img.GetAsync(x => x.ReceitasId == receitas.Id);
            var respostas = await Resp.GetAsync(x => x.ReceitasId == receitas.Id);
            var tagProj = await TagProj.GetAsync(x => x.ReceitasId == receitas.Id);
            receitas.Imagens = imgs;
            receitas.Respostas = respostas;
            receitas.Tag = tagProj;
            return receitas;
        }

        //public void Update(Receitas obj) => Receitas.Update(obj);

        //public void Create(Receitas obj) => Receitas.Insert(obj);

        //public async void Delete(int id) => await Receitas.DeleteAsync(id);

        public async Task Curtir(int id)
        {
            var receitas = await Receitas.GetByIdAssync(id);
            receitas.Likes++;
            _context.Update(receitas);
            await _context.SaveChangesAsync();
        }

        public async Task Descurtir(int id)
        {
            var receitas = await Receitas.GetByIdAssync(id);
            receitas.Unlikes++;
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
