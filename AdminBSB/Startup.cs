using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminBSB.Startup))]
namespace AdminBSB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
