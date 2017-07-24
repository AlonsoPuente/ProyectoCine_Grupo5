using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.CinePelicula
{
    public class CinePeliculaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CinePelicula";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CinePelicula_default",
                "CinePelicula/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}