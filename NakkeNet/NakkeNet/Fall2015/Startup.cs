using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NakkeNet.Startup))]
namespace NakkeNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
