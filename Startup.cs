using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DelishWebsite.Startup))]
namespace DelishWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
