using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Transience.Startup))]
namespace Transience
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
