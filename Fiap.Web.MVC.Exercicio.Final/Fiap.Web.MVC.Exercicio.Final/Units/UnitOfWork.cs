using Fiap.Web.MVC.Exercicio.Final.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fiap.Web.MVC.Exercicio.Final.Repositories;

namespace Fiap.Web.MVC.Exercicio.Final.Units
{
    public class UnitOfWork : IDisposable
    {
        private LojaContext _context = new LojaContext();

        private IGeneroRepository _generoRepository;

        public IGeneroRepository GeneroRepository
        {
            get
            {
                if (_generoRepository == null)
                {
                    _generoRepository = new GeneroRepository(_context);
                }
                return _generoRepository;
            }
        }

        private IJogoRepository _jogoRepository;

        public IJogoRepository JogoRepository
        {
            get
            {
                if (_jogoRepository == null)
                {
                    _jogoRepository = new JogoRepository(_context);
                }
                return _jogoRepository;
            }
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}