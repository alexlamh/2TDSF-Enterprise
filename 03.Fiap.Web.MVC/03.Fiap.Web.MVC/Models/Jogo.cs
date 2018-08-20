using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03.Fiap.Web.MVC.Models
{
    public class Jogo
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public bool Demo { get; set; }
        public string Plataforma { get; set; }
        public string Descricao { get; set; }
        public int IdadeMinima { get; set; }
    }
}