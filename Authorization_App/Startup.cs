using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Authorization_App.Startup))]
namespace Authorization_App
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
