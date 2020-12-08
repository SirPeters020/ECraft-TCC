using Ecraft.Api.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models.ViewModel
{
    public class PerguntasViewModel : GeneralContent
    {

        public int Id { get; set; }
        public IList<Respostas> Respostas { get; set; }
        public IList<Tags> Tags { get; set; }
        public IList<Imagens> Imagens { get; set; }

        public PerguntasViewModel()
        {

        }

        public PerguntasViewModel(Perguntas obj, List<Tags>? tags) 
            : base (obj.Title, obj.MarkdownText, obj.Date, obj.Access, obj.Likes, obj.Unlikes)
        {
            Id = obj.Id;
            Respostas = (IList<Respostas>)obj.Respostas;
            Imagens = (IList<Imagens>)obj.Imagens;
            Tags = tags;
        }

    }
}
