using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facturar.Startup))]
namespace Facturar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
