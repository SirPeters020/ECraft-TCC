using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models.Join
{
    public class TagPergunta
    {
        public Tags Tags { get; set; }
        public int TagsId { get; set; }

        public Perguntas Perguntas { get; set; }
        public int PerguntasId { get; set; }

        public TagPergunta()
        {

        }

        public TagPergunta(Tags tags, int tagsId, Perguntas perguntas, int perguntasId)
        {
            Tags = tags;
            TagsId = tagsId;
            Perguntas = perguntas;
            PerguntasId = perguntasId;
        }
    }

    public class TagProjeto
    {

        public Projetos Projetos { get; set; }
        public int ProjetosId { get; set; }
        public Tags Tag { get; set; }
        public int TagsId { get; set; }

        public TagProjeto()
        {

        }

        public TagProjeto(Projetos projetos, int projetosId, Tags tag, int tagsId)
        {
            Projetos = projetos;
            ProjetosId = projetosId;
            Tag = tag;
            TagsId = tagsId;
        }
    }

    public class TagReceita
    {
        public Tags Tags { get; set; }
        public int TagsId { get; set; }
        public Receitas Receitas { get; set; }
        public int ReceitasId { get; set; }

        public TagReceita()
        {

        }

        public TagReceita(Tags tags, int tagsId, Receitas receitas, int receitasId)
        {
            Tags = tags;
            TagsId = tagsId;
            Receitas = receitas;
            ReceitasId = receitasId;
        }
    }


}
