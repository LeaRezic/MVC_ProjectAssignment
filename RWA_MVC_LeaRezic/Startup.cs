using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RWA_MVC_LeaRezic.Startup))]
namespace RWA_MVC_LeaRezic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
