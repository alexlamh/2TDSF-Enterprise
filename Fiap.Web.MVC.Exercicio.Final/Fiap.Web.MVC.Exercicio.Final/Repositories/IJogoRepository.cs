using Fiap.Web.MVC.Exercicio.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Fiap.Web.MVC.Exercicio.Final.Repositories
{
    public interface IJogoRepository
    {
        void Cadastrar(Jogo jogo);
        void Atualizar(Jogo jogo);
        void Remover(int codigo);
        Jogo Buscar(int codigo);
        IList<Jogo> Listar();
        IList<Jogo> BuscarPor(Expression<Func<Jogo, bool>> filtro);
    }
}