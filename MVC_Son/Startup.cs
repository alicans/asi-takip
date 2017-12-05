using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Son.Startup))]
namespace MVC_Son
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
