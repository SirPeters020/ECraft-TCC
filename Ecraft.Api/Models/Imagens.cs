using Ecraft.Api.Models.Join;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models
{
    public class Imagens
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImageSrc { get; set; }

        public Receitas Receitas { get; set; }
        public int ReceitasId { get; set; }
        public Projetos Projetos { get; set; }
        public int ProjetosId { get; set; }
        public Perguntas Pergunta { get; set; }
        public int PerguntasId { get; set; }
        public Respostas Respostas { get; set; }
        public int RespostasId { get; set; }

        public Imagens()
        {

        }


    }
}
