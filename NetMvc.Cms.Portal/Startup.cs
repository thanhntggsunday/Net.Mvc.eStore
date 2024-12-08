using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetMvc.Cms.Portal.Startup))]
namespace NetMvc.Cms.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
