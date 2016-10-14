using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommandObjects.Web.Startup))]
namespace CommandObjects.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
