﻿using Ecraft.Api.Models.Join;
using Ecraft.Api.Models.Shared;
using Ecraft.Api.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecraft.Api.Models
{
    public class Receitas : GeneralContent
    {
        [Key]
        public int Id { get; set; }
        public bool Pago { get; set; }
        public double Valor { get; set; }


        //public Usuario Usuario { get; set; }
        //[ForeignKey("Usuario")]
        //public int UsuarioId { get; set; }
        public ICollection<TagReceita> Tag { get; set; }
        [NotMapped]
        public List<TagViewModel> Tags { get; set; }
        public ICollection<Imagens> Imagens { get; set; }
        public ICollection<Respostas> Respostas { get; set; }


        public Receitas()
        {

        }

        public Receitas(string titulo, string conteudo, bool pago, double valor) 
            : base (titulo, conteudo, DateTime.Now, 0, 0, 0)
        {
            Pago = pago;
            Valor = valor;
        }
    }
}
