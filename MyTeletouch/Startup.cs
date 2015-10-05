using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTeletouch.Startup))]
namespace MyTeletouch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
