using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventPark.Startup))]
namespace EventPark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
