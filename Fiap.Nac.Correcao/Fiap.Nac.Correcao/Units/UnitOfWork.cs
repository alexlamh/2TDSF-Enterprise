using Fiap.Nac.Correcao.Persistencia;
using Fiap.Nac.Correcao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Nac.Correcao.Units
{
    public class UnitOfWork : IDisposable
    {
        private VendaContext _context = new VendaContext();

        private IVendaRepository _vendaRepository;

        public IVendaRepository VendaRepository
        {
            get
            {
                if (_vendaRepository == null)
                {
                    _vendaRepository = new VendaRepository(_context);
                }
                return _vendaRepository;
            }
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context == null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}