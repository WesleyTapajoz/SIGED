using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFMT.SIGED.Application.ViewModels;
using UFMT.SIGED.Domain.Entity;
using UFMT.SIGED.Infra.Data.Context;
using UFMT.SIGED.Infra.Data.Repository;
using UFMT.SIGED.Infra.Data.UoW;

namespace UFMT.SIGED.UI.Web.Controllers
{
    public class AutenticacaoController : Controller
    {

        private SIGEDContext context = new SIGEDContext();

        private readonly UsuarioRepository _usuarioRepository;
        private readonly UnitOfWork _uow;

        public AutenticacaoController()
        {
            _usuarioRepository = new UsuarioRepository(context);
            _uow = new UnitOfWork(context);
        }


        public ActionResult Index()
        {
            return View(new LoginUsuarioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginUsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {

                var usuario = _usuarioRepository
                    .Autenticar(usuarioViewModel.Email, usuarioViewModel.Senha);

                if (usuario != null)
                {
                    usuarioViewModel = Mapper.Map<Usuario, LoginUsuarioViewModel>(usuario);
                    Session["usuario"] = usuarioViewModel;
                    return RedirectToAction("Index", "Home", new { area = "administracao" });
                }
                else
                {
                    TempData["MsgFalhaLogin"] = @"Dados incorretos.
                        Por favor, verifique seus 
                        dados e tente novamente.";
                }


            }

            return View(usuarioViewModel);
        }


        public ActionResult LogOff()
        {
            Session.Remove("usuario");
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

    }
}