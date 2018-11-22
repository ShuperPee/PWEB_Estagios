using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PWEB_Estagios.Startup))]
namespace PWEB_Estagios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
