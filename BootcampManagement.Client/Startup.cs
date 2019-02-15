using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootcampManagement.Client.Startup))]
namespace BootcampManagement.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
