using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FaceBookWebApp.Startup))]
namespace FaceBookWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
