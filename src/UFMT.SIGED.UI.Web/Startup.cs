using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UFMT.SIGED.UI.Web.Startup))]
namespace UFMT.SIGED.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
