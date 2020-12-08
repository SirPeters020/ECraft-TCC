using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecraft.Api.Models;
using Ecraft.Api.Models.Join;

namespace Ecraft.Api.Data
{
    public class ECraftContext : DbContext
    {
        public ECraftContext (DbContextOptions<ECraftContext> options)
            : base(options)
        {
        }


        // TABLES
        public DbSet<Perguntas> Perguntas { get; set; }
        public DbSet<Respostas> Respostas { get; set; }
        public DbSet<Projetos> Projetos { get; set; }
        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<User> User { get; set; }

        // JOIN TABLES
        public DbSet<TagPergunta> TagPergunta { get; set; }
        public DbSet<TagProjeto> TagProjeto { get; set; }
        public DbSet<TagReceita> TagReceita { get; set; }

        //public DbSet<ImagensProjetos> ImagesProjetos { get; set; }
        //public DbSet<ImagensPerguntas> ImagesPerguntas { get; set; }
        //public DbSet<ImagensReceitas> ImagesReceitas { get; set; }
        //public DbSet<ImagensRespostas> ImagensRespostas { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<TagPergunta>()
                .HasKey(x => new { x.TagsId, x.PerguntasId });
            builder.Entity<TagPergunta>()
                .HasOne(x => x.Tags)
                .WithMany(x => x.Pergunta)
                .HasForeignKey(x => x.TagsId);
            builder.Entity<TagPergunta>()
                .HasOne(x => x.Perguntas)
                .WithMany(x => x.Tag)
                .HasForeignKey(x => x.PerguntasId);

            builder.Entity<TagProjeto>()
                .HasKey(x => new { x.TagsId, x.ProjetosId });
            builder.Entity<TagProjeto>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.Projetos)
                .HasForeignKey(x => x.TagsId);
            builder.Entity<TagProjeto>()
                .HasOne(x => x.Projetos)
                .WithMany(x => x.Tag)
                .HasForeignKey(x => x.ProjetosId);

            builder.Entity<TagReceita>()
                .HasKey(x => new { x.TagsId, x.ReceitasId });
            builder.Entity<TagReceita>()
                .HasOne(x => x.Tags)
                .WithMany(x => x.Receitas)
                .HasForeignKey(x => x.TagsId);
            builder.Entity<TagReceita>()
                .HasOne(x => x.Receitas)
                .WithMany(x => x.Tag)
                .HasForeignKey(x => x.ReceitasId);

            //builder.Entity<ImagensProjetos>()
            //    .HasKey(x => new { x.ImagensId, x.ProjetosId });
            //builder.Entity<ImagensProjetos>()
            //    .HasOne(x => x.Imagens)
            //    .WithMany(x => x.Projetos)
            //    .HasForeignKey(x => x.ImagensId);
            //builder.Entity<ImagensProjetos>()
            //    .HasOne(x => x.Projetos)
            //    .WithMany(x => x.Imagens)
            //    .HasForeignKey(x => x.ProjetosId);

            //builder.Entity<ImagensPerguntas>()
            //    .HasKey(x => new { x.ImagensId, x.PerguntasId });
            //builder.Entity<ImagensPerguntas>()
            //    .HasOne(x => x.Imagens)
            //    .WithMany(x => x.Pergunta)
            //    .HasForeignKey(x => x.ImagensId);
            //builder.Entity<ImagensPerguntas>()
            //    .HasOne(x => x.Perguntas)
            //    .WithMany(x => x.Imagens)
            //    .HasForeignKey(x => x.PerguntasId);

            //builder.Entity<ImagensReceitas>()
            //    .HasKey(x => new { x.ImagensId, x.ReceitasId });
            //builder.Entity<ImagensReceitas>()
            //    .HasOne(x => x.Imagens)
            //    .WithMany(x => x.Receitas)
            //    .HasForeignKey(x => x.ImagensId);
            //builder.Entity<ImagensReceitas>()
            //    .HasOne(x => x.Receitas)
            //    .WithMany(x => x.Imagens)
            //    .HasForeignKey(x => x.ReceitasId);

            //builder.Entity<ImagensRespostas>()
            //    .HasKey(x => new { x.ImagensId, x.RespostasId });
            //builder.Entity<ImagensRespostas>()
            //    .HasOne(x => x.Imagens)
            //    .WithMany(x => x.Respostas)
            //    .HasForeignKey(x => x.ImagensId);
            //builder.Entity<ImagensRespostas>()
            //    .HasOne(x => x.Respostas)
            //    .WithMany(x => x.Imagens)
            //    .HasForeignKey(x => x.RespostasId);


            //builder.Entity<Respostas>()
            //    .HasOne(x => x.Pergunta)
            //    .WithMany(x => x.Respostas)
            //    .HasForeignKey(x => x.UsuarioId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
