using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dziennik.Startup))]
namespace dziennik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
