using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechNote.WebUI.Startup))]
namespace TechNote.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
