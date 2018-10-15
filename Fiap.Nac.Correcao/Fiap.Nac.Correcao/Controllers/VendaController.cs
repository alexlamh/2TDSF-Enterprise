using Fiap.Nac.Correcao.Models;
using Fiap.Nac.Correcao.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Nac.Correcao.Controllers
{
    public class VendaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpPost]
        public ActionResult Pagar(int codigo)
        {
            var venda = _unit.VendaRepository
                .BuscarPor(v => v.Codigo == codigo)[0];
            venda.Pago = true;
            _unit.VendaRepository.Atualizar(venda);
            _unit.Salvar();
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(string nome)
        {
            var lista = _unit.VendaRepository
                   .BuscarPor(v => v.Cliente.Contains(nome));
            return View("Listar",lista);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_unit.VendaRepository.Listar());
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Venda venda)
        {
            _unit.VendaRepository.Cadastrar(venda);
            _unit.Salvar();
            TempData["msg"] = "Cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}