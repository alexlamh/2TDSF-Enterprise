using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Fiap.Nac.Correcao.Models;
using Fiap.Nac.Correcao.Persistencia;

namespace Fiap.Nac.Correcao.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private VendaContext _context;

        public VendaRepository(VendaContext context)
        {
            _context = context;
        }

        public void Atualizar(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
        }

        public IList<Venda> BuscarPor(Expression<Func<Venda, bool>> filtro)
        {
            return _context.Vendas.Where(filtro).ToList();
        }

        public void Cadastrar(Venda venda)
        {
            venda.Pago = false;
            _context.Vendas.Add(venda);
        }

        public IList<Venda> Listar()
        {
            return _context.Vendas.ToList();
        }
    }
}