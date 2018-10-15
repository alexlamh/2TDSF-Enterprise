using Fiap.Nac.Correcao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Nac.Correcao.Repository
{
    public interface IVendaRepository
    {
        void Cadastrar(Venda venda);
        void Atualizar(Venda venda);
        IList<Venda> Listar();
        IList<Venda> BuscarPor(Expression<Func<Venda, bool>> filtro);
    }
}
