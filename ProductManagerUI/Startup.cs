using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductManagerUI.Startup))]
namespace ProductManagerUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
