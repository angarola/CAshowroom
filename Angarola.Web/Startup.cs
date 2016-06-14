using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Angarola.Web.Startup))]
namespace Angarola.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
