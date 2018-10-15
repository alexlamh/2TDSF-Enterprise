using Fiap.Nac.Correcao.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fiap.Nac.Correcao.Persistencia
{
    public class VendaContext : DbContext
    {
        public DbSet<Venda> Vendas { get; set; }
    }
}