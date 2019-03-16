using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lesson6.MySecurityApplication.Startup))]
namespace Lesson6.MySecurityApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
