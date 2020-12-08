using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecraft.Api.Models.Join;

namespace Ecraft.Api.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Tag { get; set; }

        public ICollection<TagReceita> Receitas { get; set; }
        public ICollection<TagProjeto> Projetos { get; set; }
        public ICollection<TagPergunta> Pergunta { get; set; }

        public Tags()
        {

        }
        public Tags(string tag)
        {
            Tag = tag;
        }

    }
}
