using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nimbow.Samples.AspNetMvcMfa.Startup))]
namespace Nimbow.Samples.AspNetMvcMfa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
