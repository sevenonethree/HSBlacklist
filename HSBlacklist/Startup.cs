using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HSBlacklist.Startup))]
namespace HSBlacklist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
