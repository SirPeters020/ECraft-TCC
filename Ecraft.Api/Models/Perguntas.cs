using Ecraft.Api.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ecraft.Api.Models.Join;
using Ecraft.Api.Models.ViewModel;

namespace Ecraft.Api.Models
{
    public class Perguntas : GeneralContent
    {
        [Key]
        public int Id { get; set; }
        //public Usuario Usuario { get; set; }
        //[ForeignKey("Usuario")]
        //public int UsuarioId { get; set; }
        public ICollection<Respostas> Respostas { get; set; }
        public ICollection<TagPergunta> Tag { get; set; }
        [NotMapped]
        public List<TagViewModel> Tags { get; set; }
        public ICollection<Imagens> Imagens { get; set; }

        public Perguntas()
        {

        }

        public Perguntas(string titulo, string conteudo) : base (titulo, conteudo, DateTime.Now, 0, 0, 0)
        {

        }
    

    }
}
