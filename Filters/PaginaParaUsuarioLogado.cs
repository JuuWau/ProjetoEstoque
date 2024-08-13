using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Estoque.Models;
using Newtonsoft.Json;

namespace Estoque.Filters{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)){
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller", "Login"}, {"action", "Index"}});
            } else {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

                if (usuario == null){
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller", "Login"}, {"action", "Index"}});
                }
            }

            base.OnActionExecuting(context);
        }
    }
}