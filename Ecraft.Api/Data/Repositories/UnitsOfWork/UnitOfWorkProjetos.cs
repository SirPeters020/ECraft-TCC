using Ecraft.Api.Models;
using Ecraft.Api.Models.Join;
using Ecraft.Api.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Ecraft.Api.Data.Repositories.UnitsOfWork
{
    public class UnitOfWorkProjetos
    {

        private readonly ECraftContext _context;
        public BaseRepository<Projetos> Projetos { get; set; }
        public BaseRepository<TagProjeto> TagProj { get; set; }
        public BaseRepository<Tags> Tag { get; set; }
        public BaseRepository<Imagens> Img { get; set; }
        public BaseRepository<Respostas> Resp { get; set; }

        public UnitOfWorkProjetos(ECraftContext context)
        {
            _context = context;
            Projetos = new BaseRepository<Projetos>(context);
            TagProj = new BaseRepository<TagProjeto>(context);
            Tag = new BaseRepository<Tags>(context);
            Img = new BaseRepository<Imagens>(context);
            Resp = new BaseRepository<Respostas>(context);
        }

        //public async Task<List<Projetos>> GetAll() => (List<Projetos>) await Projetos.GetAsync();

        public async Task<Projetos> GetById(int id)
        {
            var projeto = await Projetos.GetByIdAssync(id);
            if (projeto == null) return null;
            var imgs = await Img.GetAsync(x => x.ProjetosId == projeto.Id);
            var respostas = await Resp.GetAsync(x => x.ProjetosId == projeto.Id);
            var tagProj = await TagProj.GetAsync(x => x.ProjetosId == projeto.Id);
            var lisTags = new List<Tags>();
            projeto.Respostas = respostas;
            projeto.Imagens = imgs;
            projeto.Tag = tagProj;
            return projeto;
        }

        //public void Update(Projetos proj) => Projetos.Update(proj);

        //public void Create(Projetos proj) => Projetos.Insert(proj);

        //public async void Delete(int id) => await Projetos.DeleteAsync(id);

        public async Task Curtir(int id)
        {
            var projeto = await Projetos.GetByIdAssync(id);
            projeto.Likes++;
            _context.Update(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task Descurtir(int id)
        {
            var projeto = await Projetos.GetByIdAssync(id);
            projeto.Unlikes++;
            await _context.SaveChangesAsync();
        }

        public async Task Acessos(Projetos proj)
        {
            proj.Access++;
            await _context.SaveChangesAsync();
        }

        public async Task CommitAssync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
