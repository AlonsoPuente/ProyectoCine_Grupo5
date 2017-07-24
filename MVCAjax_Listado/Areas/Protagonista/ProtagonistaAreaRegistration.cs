using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Protagonista
{
    public class ProtagonistaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Protagonista";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Protagonista_default",
                "Protagonista/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}