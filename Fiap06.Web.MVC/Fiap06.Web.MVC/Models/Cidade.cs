using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap06.Web.MVC.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }

        public Estado Estado { get; set; }
        public int EstadoId { get; set; }
    }
}