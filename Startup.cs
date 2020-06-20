using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPTute_Vidly.Startup))]
namespace ASPTute_Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
