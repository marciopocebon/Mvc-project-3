using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UltimateLabs.Web.Startup))]
namespace UltimateLabs.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
