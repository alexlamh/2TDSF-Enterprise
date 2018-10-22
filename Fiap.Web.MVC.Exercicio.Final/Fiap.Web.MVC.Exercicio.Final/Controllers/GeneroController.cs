using Fiap.Web.MVC.Exercicio.Final.Models;
using Fiap.Web.MVC.Exercicio.Final.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Web.MVC.Exercicio.Final.Controllers
{
    public class GeneroController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Genero genero)
        {
            _unit.GeneroRepository.Cadastrar(genero);
            _unit.Salvar();
            TempData["msg"] = "Cadastrado com sucesso";
            return RedirectToAction("Cadastrar");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}