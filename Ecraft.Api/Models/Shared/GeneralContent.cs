using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models.Shared
{
    public class GeneralContent
    {
        [Required(ErrorMessage = "Este Campo não pode ser vazio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Este Campo não pode ser vazio")]
        public string MarkdownText { get; set; }

        public DateTime Date { get; set; }

        public int Access { get; set; }
        public int Likes { get; set; }
        public int Unlikes { get; set; }


        public GeneralContent()
        {

        }

        public GeneralContent(string titulo, string conteudo, DateTime data, int acessos, int curtidas, int descurtidas)
        {
            Title = titulo;
            MarkdownText = conteudo;
            Date = data;
            Access = acessos;
            Likes = curtidas;
            Unlikes = descurtidas;
        }
    }
}
