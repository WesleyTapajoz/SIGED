using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UFMT.SIGED.Domain.Entity;
using UFMT.SIGED.Infra.Data.Context;
using UFMT.SIGED.Infra.Data;
using UFMT.SIGED.Infra.Data.UoW;
using UFMT.SIGED.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using PagedList;
using PagedList.Mvc;
using UFMT.SIGED.UI.Web.Filtros;

namespace Areas.Administracao.Controllers
{
    [AutorizacaoUsuarioFilter]
    public class NivelEnsinoController : Controller
    {
        private SIGEDContext context = new SIGEDContext();

        private readonly NivelEnsinoRepository _repository;
        private readonly UnitOfWork _uow;
        private const int pageSize = 10;

        public NivelEnsinoController()
        {
            _repository = new NivelEnsinoRepository(context);
            _uow = new UnitOfWork(context);
        }

        public ActionResult DetalheNivelEnsinoEstudante()
        {
            var estudanteNivelEnsino =
                _repository
                .ObterPorId(1);

            var vm = new EstudanteNivelEnsinoViewModel
            {
                NivelEnsinoId = estudanteNivelEnsino.NivelEnsinoId,
                Descricao = estudanteNivelEnsino.Descricao,
                Nome = estudanteNivelEnsino.Estudantes.FirstOrDefault().Nome,
                EstudanteId = estudanteNivelEnsino.Estudantes.FirstOrDefault().EstudanteId,
                DataNascimento = estudanteNivelEnsino.Estudantes.FirstOrDefault().DataNascimento,
                TotalEstudantes = estudanteNivelEnsino.Estudantes.Count()

            };

            return View(vm);
        }

        public ActionResult ObterMaiorNivelEnsino()
        {
            var vm = _repository.ObterTodos().AsQueryable()
                .ProjectTo<NivelDeEnsinoViewModel>()
                .FirstOrDefault();
            return PartialView("_ObterMaiorNivelEnsino", vm);
        }


        public ActionResult Buscar(int? pagina, string criterio = null)
        {
            //Sleep de 5 segundos apenas para visualizar o loading
            //Não adicionar em produção
            Thread.Sleep(5000);

            int pageNumber = pagina ?? 1;

            var niveisEnsino = _repository
                .ObterTodos();

            if (!String.IsNullOrWhiteSpace(criterio))
            {

                niveisEnsino =
                        _repository
                        .Buscar(e =>
                                e.Descricao.ToUpper()
                                .Contains(criterio.ToUpper())
                               );
            }

            var vm = niveisEnsino.AsQueryable()
                .ProjectTo<NivelDeEnsinoViewModel>();

            return PartialView("_ObterTodos", vm.OrderBy(x => x.Descricao)
                .ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Index(int? pagina)
        {
            #region erro de lógica

            string[] nomes = new string[] { "Marcio", "Guilherme" };
            string nome = nomes[2];

            #endregion

            int pageNumber = pagina ?? 1;

            var vm = _repository.ObterTodos().AsQueryable()
                .ProjectTo<NivelDeEnsinoViewModel>();

            return View(vm.OrderBy(x=>x.Descricao)
                .ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            var nivelEnsino = 
                _repository
                .ObterPorId(id.GetValueOrDefault());

            var vm =
                Mapper.Map<NivelEnsino,
                NivelDeEnsinoViewModel>(nivelEnsino);

            return PartialView("_Details", vm);
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            AdicionarNivelEnsinoViewModel nivelEnsinoVM)
        {

            //Sleep de 5 segundos apenas para visualizar o loading
            //Não adicionar em produção
            Thread.Sleep(5000);

            if (ModelState.IsValid)
            {
                _uow.BeginTransaction();

                var nivelEnsino =
                    Mapper.Map<AdicionarNivelEnsinoViewModel,
                    NivelEnsino>(nivelEnsinoVM);

                _repository.Adicionar(nivelEnsino);
                _uow.Commit();

                return ObterTodos();
            }

            return PartialView("_Create", nivelEnsinoVM);
        }

        
        public ActionResult Edit(int? id)
        {

            var nivelEnsino = 
                _repository
                .ObterPorId(id.GetValueOrDefault());

            var vm =
                Mapper.Map<NivelEnsino,
                AtualizarNivelEnsinoViewModel>(nivelEnsino);


            return PartialView("_Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            AtualizarNivelEnsinoViewModel nivelEnsinoVM)
        {
            //Sleep de 5 segundos apenas para visualizar o loading
            //Não adicionar em produção
            Thread.Sleep(5000);

            if (ModelState.IsValid)
            {
                _uow.BeginTransaction();

                var nivelEnsino =
                    Mapper.Map<AtualizarNivelEnsinoViewModel,
                    NivelEnsino>(nivelEnsinoVM);

                _repository.Atualizar(nivelEnsino);
                _uow.Commit();

                return ObterTodos();
            }
            return PartialView("_Edit", nivelEnsinoVM);
        }

        public ActionResult Delete(int? id)
        {
            var nivelEnsino =
                _repository
                .ObterPorId(id.GetValueOrDefault());

            var vm =
                Mapper.Map<NivelEnsino,
                NivelDeEnsinoViewModel>(nivelEnsino);

            return PartialView("_Delete", vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Sleep de 5 segundos apenas para visualizar o loading
            //Não adicionar em produção
            Thread.Sleep(5000);

            _uow.BeginTransaction();
            _repository.Remover(id);
            _uow.Commit();

            var vm = _repository.ObterTodos().AsQueryable()
                .ProjectTo<NivelDeEnsinoViewModel>();
            return ObterTodos();
        }

        public ActionResult ObterTodos()
        {
            var vm = _repository.ObterTodos().AsQueryable()
            .ProjectTo<NivelDeEnsinoViewModel>();

            return PartialView("_ObterTodos", vm.OrderBy(x => x.Descricao)
                    .ToPagedList(1, pageSize));
        }

    }
}
