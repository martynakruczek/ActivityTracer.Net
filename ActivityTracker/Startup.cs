using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ActivityTracker.Startup))]
namespace ActivityTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
