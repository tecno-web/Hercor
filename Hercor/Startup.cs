using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hercor.Startup))]
namespace Hercor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
