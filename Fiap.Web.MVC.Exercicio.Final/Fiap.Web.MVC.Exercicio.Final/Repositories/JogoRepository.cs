using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fiap.Web.MVC.Exercicio.Final.Models;
using Fiap.Web.MVC.Exercicio.Final.Persistencia;

namespace Fiap.Web.MVC.Exercicio.Final.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private LojaContext _context;

        public JogoRepository(LojaContext context)
        {
            _context = context;
        }

        public void Atualizar(Jogo jogo)
        {
            _context.Entry(jogo).State = EntityState.Modified;
        }

        public Jogo Buscar(int codigo)
        {
            return _context.Jogos.Find(codigo);
        }

        public IList<Jogo> BuscarPor(Expression<Func<Jogo, bool>> filtro)
        {
            return _context.Jogos.Include("Genero").Where(filtro).ToList();
        }

        public void Cadastrar(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
        }

        public IList<Jogo> Listar()
        {
            return _context.Jogos.Include("Genero").ToList();
        }

        public void Remover(int codigo)
        {
            var jogo = Buscar(codigo);
            _context.Jogos.Remove(jogo);
        }
    }
}