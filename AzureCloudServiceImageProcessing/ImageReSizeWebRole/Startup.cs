using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageReSizeWebRole.Startup))]
namespace ImageReSizeWebRole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
