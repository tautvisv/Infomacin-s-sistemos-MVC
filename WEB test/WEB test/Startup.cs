using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OroUostoSistema.Startup))]
namespace OroUostoSistema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
