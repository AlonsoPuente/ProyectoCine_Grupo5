using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Pelicula
{
    public class PeliculaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Pelicula";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Pelicula_default",
                "Pelicula/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}