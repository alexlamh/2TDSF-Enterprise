using Fiap06.Web.MVC.Models;
using Fiap06.Web.MVC.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap06.Web.MVC.Controllers
{
    public class CidadeController : Controller
    {
        private PaisContext _context = new PaisContext();

        [HttpGet]
        public ActionResult Buscar(int? estado)
        {
            CarregarCombo();            
            var lista = _context.Cidades.Include("Estado")
                    .Where(c => c.EstadoId == estado || 
                     estado == null).ToList();
            return View("Listar",lista);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            CarregarCombo();
            var lista = _context.Cidades.Include("Estado").ToList();
            return View(lista);
        }

        private void CarregarCombo()
        {
            var ufs = _context.Estados.ToList();
            ViewBag.estados = new SelectList(ufs, "EstadoId", "Nome");
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            CarregarCombo();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            _context.SaveChanges();
            TempData["msg"] = "Cidade cadastrada";
            return RedirectToAction("Cadastrar");
        }
    }
}