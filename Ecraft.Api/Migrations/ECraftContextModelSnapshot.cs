﻿// <auto-generated />
using System;
using Ecraft.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecraft.Api.Migrations
{
    [DbContext(typeof(ECraftContext))]
    partial class ECraftContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Ecraft.Api.Models.Imagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerguntasId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetosId")
                        .HasColumnType("int");

                    b.Property<int>("ReceitasId")
                        .HasColumnType("int");

                    b.Property<int>("RespostasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerguntasId");

                    b.HasIndex("ProjetosId");

                    b.HasIndex("ReceitasId");

                    b.HasIndex("RespostasId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Join.TagPergunta", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("PerguntasId")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "PerguntasId");

                    b.HasIndex("PerguntasId");

                    b.ToTable("TagPergunta");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Join.TagProjeto", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetosId")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "ProjetosId");

                    b.HasIndex("ProjetosId");

                    b.ToTable("TagProjeto");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Join.TagReceita", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("ReceitasId")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "ReceitasId");

                    b.HasIndex("ReceitasId");

                    b.ToTable("TagReceita");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Perguntas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Access")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("MarkdownText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unlikes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Projetos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Access")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("MarkdownText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unlikes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Receitas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Access")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("MarkdownText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unlikes")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Respostas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Curtidas")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PerguntaId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjetosId")
                        .HasColumnType("int");

                    b.Property<int?>("ReceitasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerguntaId");

                    b.HasIndex("ProjetosId");

                    b.HasIndex("ReceitasId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Ecraft.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Imagens", b =>
                {
                    b.HasOne("Ecraft.Api.Models.Perguntas", "Pergunta")
                        .WithMany("Imagens")
                        .HasForeignKey("PerguntasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecraft.Api.Models.Projetos", "Projetos")
                        .WithMany("Imagens")
                        .HasForeignKey("ProjetosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecraft.Api.Models.Receitas", "Receitas")
                        .WithMany("Imagens")
                        .HasForeignKey("ReceitasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecraft.Api.Models.Respostas", "Respostas")
                        .WithMany("Imagens")
                        .HasForeignKey("RespostasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pergunta");

                    b.Navigation("Projetos");

                    b.Navigation("Receitas");

                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Join.TagPergunta", b =>
                {
                    b.HasOne("Ecraft.Api.Models.Perguntas", "Perguntas")
                        .WithMany("Tags")
                        .HasForeignKey("PerguntasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecraft.Api.Models.Tags", "Tags")
                        .WithMany("Pergunta")
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perguntas");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Join.TagProjeto", b =>
                {
                    b.HasOne("Ecraft.Api.Models.Projetos", "Projetos")
                        .WithMany("Tags")
                        .HasForeignKey("ProjetosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecraft.Api.Models.Tags", "Tag")
                        .WithMany("Projetos")
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projetos");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Join.TagReceita", b =>
                {
                    b.HasOne("Ecraft.Api.Models.Receitas", "Receitas")
                        .WithMany("Tags")
                        .HasForeignKey("ReceitasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecraft.Api.Models.Tags", "Tags")
                        .WithMany("Receitas")
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receitas");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Respostas", b =>
                {
                    b.HasOne("Ecraft.Api.Models.Perguntas", "Pergunta")
                        .WithMany("Respostas")
                        .HasForeignKey("PerguntaId");

                    b.HasOne("Ecraft.Api.Models.Projetos", "Projetos")
                        .WithMany("Respostas")
                        .HasForeignKey("ProjetosId");

                    b.HasOne("Ecraft.Api.Models.Receitas", "Receitas")
                        .WithMany("Respostas")
                        .HasForeignKey("ReceitasId");

                    b.Navigation("Pergunta");

                    b.Navigation("Projetos");

                    b.Navigation("Receitas");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Perguntas", b =>
                {
                    b.Navigation("Imagens");

                    b.Navigation("Respostas");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Projetos", b =>
                {
                    b.Navigation("Imagens");

                    b.Navigation("Respostas");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Receitas", b =>
                {
                    b.Navigation("Imagens");

                    b.Navigation("Respostas");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Respostas", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("Ecraft.Api.Models.Tags", b =>
                {
                    b.Navigation("Pergunta");

                    b.Navigation("Projetos");

                    b.Navigation("Receitas");
                });
#pragma warning restore 612, 618
        }
    }
}
