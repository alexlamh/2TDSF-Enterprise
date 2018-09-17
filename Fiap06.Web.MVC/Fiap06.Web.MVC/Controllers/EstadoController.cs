using Fiap06.Web.MVC.Models;
using Fiap06.Web.MVC.Persistencia;
using Fiap06.Web.MVC.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap06.Web.MVC.Controllers
{
    public class EstadoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Estado estado)
        {
            _unit.EstadoRepository.Cadastrar(estado);
            _unit.Salvar();
            TempData["msg"] = "Estado cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}