using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFMT.SIGED.UI.Web.Filtros;

namespace Areas.Administracao.Controllers
{
    [AutorizacaoUsuarioFilter]  
    public class HomeController : Controller
    {
        // GET: Administracao/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}