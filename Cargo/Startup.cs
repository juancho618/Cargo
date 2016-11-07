using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cargo.Startup))]
namespace Cargo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //SignalR
            app.MapSignalR();
        }
    }
}
