using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLambda.Startup))]
namespace WebLambda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
