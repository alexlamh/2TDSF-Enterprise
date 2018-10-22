using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.MVC.Exercicio.Final.Models
{
    public class Jogo
    {
        public int JogoId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }
        public Plataforma? Plataforma { get; set; }
        public bool Disponivel { get; set; }
        public Genero Genero { get; set; }
        public int GeneroId { get; set; }
    }
}