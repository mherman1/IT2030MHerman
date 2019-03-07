using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab8Appplication.Startup))]
namespace Lab8Appplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
