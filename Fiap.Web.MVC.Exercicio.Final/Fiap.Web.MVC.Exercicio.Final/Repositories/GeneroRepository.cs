using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fiap.Web.MVC.Exercicio.Final.Models;
using Fiap.Web.MVC.Exercicio.Final.Persistencia;

namespace Fiap.Web.MVC.Exercicio.Final.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {

        private LojaContext _context;

        public GeneroRepository(LojaContext context)
        {
            _context = context;
        }

        public void Cadastrar(Genero genero)
        {
            _context.Generos.Add(genero);
        }

        public IList<Genero> Listar()
        {
            return _context.Generos.ToList();
        }
    }
}