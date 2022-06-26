using System.Web.Mvc;
using System.Web.Routing;

namespace ExamenResuelto.App_Start
{
    public class Validation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Rol"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Index",
                    Controller = "Home"
                }));
            }
        }
    }

    public class AdminValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Rol"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Index",
                    Controller = "Home"
                }));
            }
            else if(filterContext.HttpContext.Session["Rol"].ToString() != "1")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Index",
                    Controller = "Home"
                }));
            }
        }
    }

    public class AlreadyLogged : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Rol"] != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Index",
                    Controller = "Home"
                }));
            }
        }
    }
}