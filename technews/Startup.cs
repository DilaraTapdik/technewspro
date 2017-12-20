using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(technews.Startup))]
namespace technews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
