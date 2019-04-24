using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lesson13.CustomHRApplication.Startup))]
namespace Lesson13.CustomHRApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
