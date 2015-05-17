using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace OroUostoSistema.Attributes
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
       protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
       {
           if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
           {
               filterContext.Result = new HttpUnauthorizedResult();
           }
           else
           {
               filterContext.Result = new RedirectToRouteResult(new
                   RouteValueDictionary(new { controller = "Vartotojas" }));
           }
       }
    }
}