using Fiap.Web.MVC.Exercicio.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fiap.Web.MVC.Exercicio.Final.Repositories
{
    public interface IGeneroRepository
    {
        void Cadastrar(Genero genero);
        IList<Genero> Listar();
    }
}