using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FaceBook.Services.Startup))]

namespace FaceBook.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
