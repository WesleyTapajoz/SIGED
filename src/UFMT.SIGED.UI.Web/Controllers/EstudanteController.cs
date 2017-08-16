using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UFMT.SIGED.Domain.Entity;
using UFMT.SIGED.Infra.Data;
using UFMT.SIGED.Infra.Data.Context;
using UFMT.SIGED.Infra.Data.UoW;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using UFMT.SIGED.Application.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace UFMT.SIGED.UI.Web.Controllers
{
    public class EstudanteController : Controller
    {
        private SIGEDContext context = new SIGEDContext();
        private readonly EstudanteRepository
            _estudanteRepository;
        private readonly NivelEnsinoRepository
            _nivelEnsinoRepository;
        private readonly UnitOfWork _uow;

        public EstudanteController()
        {
            _estudanteRepository =
                new EstudanteRepository(context);
            _nivelEnsinoRepository =
                new NivelEnsinoRepository(context);
            _uow = new UnitOfWork(context);
        }

        // GET: Estudante
        public ActionResult Index(int? pagina)
        {
            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;

            var estudantesVM = _estudanteRepository
                .ObterTodos().AsQueryable()
                .ProjectTo<EstudanteViewModel>();

            return View(estudantesVM
                .ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Estudante/Details/5
        public ActionResult Details(int? id)
        {
            var estudante =
                _estudanteRepository
                .ObterPorId(id.GetValueOrDefault());

            var estudanteVM =
                Mapper.Map<Estudante, 
                EstudanteViewModel>(estudante);

            return View(estudanteVM);
        }

        public ActionResult Create()
        {
            ViewBag.Messagem = "Preencha os dados com atenção";

              ViewBag.NivelEnsinoId = 
              new SelectList(_nivelEnsinoRepository.ObterTodos(),
              "NivelEnsinoId", "Descricao");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            AdicionarEstudanteViewModel estudanteVM)
        {
            if (ModelState.IsValid)
            {
                var estudante =
                    Mapper.Map<AdicionarEstudanteViewModel,
                    Estudante>(estudanteVM);
                _uow.BeginTransaction();
                _estudanteRepository.Adicionar(estudante);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.NivelEnsinoId = 
                new SelectList(_nivelEnsinoRepository.ObterTodos(), 
                "NivelEnsinoId", "Descricao", estudanteVM.NivelEnsinoId);
            return View(estudanteVM);
        }

        // GET: Estudante/Edit/5
        public ActionResult Edit(int? id)
        {
            var estudante = 
                _estudanteRepository.ObterPorId(id.GetValueOrDefault());
            var estudanteVM =
                Mapper.Map<Estudante, 
                EstudanteViewModel>(estudante);
            ViewBag.NivelEnsinoId = 
                new SelectList(_nivelEnsinoRepository.ObterTodos(), 
                "NivelEnsinoId", "Descricao", estudante.NivelEnsinoId);
            return View(estudanteVM);
        }

        // POST: Estudante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            AtualizarEstudanteViewModel estudanteVM)
        {
            if (ModelState.IsValid)
            {
                var estudante = Mapper
                    .Map<AtualizarEstudanteViewModel,
                    Estudante>(estudanteVM);
                _uow.BeginTransaction();
                _estudanteRepository.Atualizar(estudante);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.NivelEnsinoId = 
                new SelectList(_nivelEnsinoRepository.ObterTodos(), 
                "NivelEnsinoId", "Descricao", estudanteVM.NivelEnsinoId);
            return View(estudanteVM);
        }

        // GET: Estudante/Delete/5
        public ActionResult Delete(int? id)
        {
            var estudante = _estudanteRepository
                .ObterPorId(id.GetValueOrDefault());
            var estudanteVM = Mapper.Map<Estudante,
                EstudanteViewModel>(estudante);

            return View(estudanteVM);
        }

        // POST: Estudante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.BeginTransaction();
            _estudanteRepository.Remover(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }


    }
}
