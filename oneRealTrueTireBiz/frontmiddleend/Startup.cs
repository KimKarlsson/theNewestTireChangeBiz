using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(frontmiddleend.Startup))]
namespace frontmiddleend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
