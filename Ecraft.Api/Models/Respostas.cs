using Ecraft.Api.Models.Join;
using Ecraft.Api.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models
{
    public class Respostas
    {
        [Key]
        public int Id { get; set; }
        public int Curtidas { get; set; }
        public DateTime Data { get; set; }


        //public Usuario Usuario { get; set; }
        //[ForeignKey("Usuario")]
        //public int UsuarioId { get; set; }
        public Perguntas? Pergunta { get; set; }
        [ForeignKey("Pergunta")]
        public int? PerguntaId { get; set; }
        public Receitas? Receitas { get; set; }
        public int? ReceitasId { get; set; }
        public Projetos? Projetos { get; set; }
        public int? ProjetosId { get; set; }
        public ICollection<Imagens> Imagens { get; set; }

        public Respostas()
        {

        }

        public Respostas(int id, int curtidas, DateTime data, Perguntas pergunta, int perguntaId)
        {
            Id = id;
            Curtidas = curtidas;
            Data = data;
            Pergunta = pergunta;
            PerguntaId = perguntaId;
        }
    }
}
