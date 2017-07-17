using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAjax_Listado.Startup))]
namespace MVCAjax_Listado
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
