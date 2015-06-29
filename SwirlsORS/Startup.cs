using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootstrapMVC.Startup))]
namespace BootstrapMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
