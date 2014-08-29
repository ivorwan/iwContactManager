using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iwContactManager.Startup))]
namespace iwContactManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
