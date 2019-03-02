using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMART_CITIES.Startup))]
namespace SMART_CITIES
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
