using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UFMT.SIGED.UI.Web.Filtros
{
    public class AutorizacaoUsuarioFilterAttribute :
            ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuarioLogado = filterContext
                .HttpContext.Session["usuario"];
            if (usuarioLogado == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                          new RouteValueDictionary(
                              new
                              {

                                  action = "Index",
                                  controller = "Autenticacao",
                                  area = ""

                              }));
            }
        }
    }
}