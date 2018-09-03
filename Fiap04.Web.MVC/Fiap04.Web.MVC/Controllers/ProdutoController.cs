using Fiap04.Web.MVC.Models;
using Fiap04.Web.MVC.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap04.Web.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private PetshopContext _context = new PetshopContext();

        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            //Pesquisar por nome no banco 
            var lista = _context.Produtos
                .Where(p => p.Nome.Contains(nomeBusca)).ToList();
            //Joga a lista para a tela de Listar
            return View("Listar",lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            TempData["msg"] = "Produto atualizado!";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var p = _context.Produtos.Find(id);
            _context.Produtos.Remove(p);
            _context.SaveChanges();
            TempData["msg"] = "Removido!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_context.Produtos.ToList());
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            TempData["msg"] = "Produto cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}