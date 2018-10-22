using Fiap.Web.MVC.Exercicio.Final.Models;
using Fiap.Web.MVC.Exercicio.Final.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Web.MVC.Exercicio.Final.Controllers
{
    public class JogoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult BuscarPorGenero(int generoId)
        {
            var lista = _unit.JogoRepository.BuscarPor(j => j.GeneroId == generoId);
            CarregarSelectGeneros();
            return View("Listar", lista);
        }

        [HttpGet]
        public ActionResult BuscarPorNome(string nome)
        {
            var lista = _unit.JogoRepository.BuscarPor(j => j.Nome.Contains(nome));
            CarregarSelectGeneros();
            return View("Listar", lista);
        }

        [HttpPost]
        public ActionResult Disponibilizar(int codigo)
        {
            var jogo = _unit.JogoRepository.Buscar(codigo);
            jogo.Disponivel = true;
            _unit.JogoRepository.Atualizar(jogo);
            _unit.Salvar();
            TempData["msg"] = "Jogo disponibilizado";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Remover(int codigo)
        {
            _unit.JogoRepository.Remover(codigo);
            _unit.Salvar();
            TempData["msg"] = "Jogo removido";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            CarregarSelectGeneros();
            var jogo = _unit.JogoRepository.Buscar(id);
            return View(jogo);
        }

        [HttpPost]
        public ActionResult Editar(Jogo jogo)
        {
            _unit.JogoRepository.Atualizar(jogo);
            _unit.Salvar();
            TempData["msg"] = "Jogo Atualizado";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            CarregarSelectGeneros();
            var lista = _unit.JogoRepository.Listar();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            CarregarSelectGeneros();
            return View();
        }

        private void CarregarSelectGeneros()
        {
            var lista = _unit.GeneroRepository.Listar();
            ViewBag.generos = new SelectList(lista, "GeneroId", "Nome");
        }

        [HttpPost]
        public ActionResult Cadastrar(Jogo jogo)
        {
            _unit.JogoRepository.Cadastrar(jogo);
            _unit.Salvar();
            TempData["msg"] = "Cadastrado com sucesso";
            return RedirectToAction("Listar");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}