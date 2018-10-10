using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ErestaurantApp.Startup))]
namespace ErestaurantApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
