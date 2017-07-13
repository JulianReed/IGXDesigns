using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IGXDesigns.Startup))]
namespace IGXDesigns
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
