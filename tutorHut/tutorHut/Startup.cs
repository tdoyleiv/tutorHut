using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tutorHut.Startup))]
namespace tutorHut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
