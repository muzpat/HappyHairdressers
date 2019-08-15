using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HappyHairdressers.Startup))]
namespace HappyHairdressers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
