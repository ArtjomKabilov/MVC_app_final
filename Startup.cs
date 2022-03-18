using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KutseApp.Startup))]
namespace KutseApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
