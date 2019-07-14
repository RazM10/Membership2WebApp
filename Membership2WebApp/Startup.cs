using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Membership2WebApp.Startup))]
namespace Membership2WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
