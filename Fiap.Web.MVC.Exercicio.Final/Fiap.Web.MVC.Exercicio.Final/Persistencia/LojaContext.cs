using Fiap.Web.MVC.Exercicio.Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fiap.Web.MVC.Exercicio.Final.Persistencia
{
    public class LojaContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}