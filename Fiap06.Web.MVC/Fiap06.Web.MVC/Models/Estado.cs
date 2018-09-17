using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fiap06.Web.MVC.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }

        [MaxLength(2)]
        public string Sigla { get; set; }

        public int Populacao { get; set; }

        public List<Cidade> Cidades { get; set; }
    }
}