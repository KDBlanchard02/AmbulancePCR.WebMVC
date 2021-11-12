using AmbulancePCR.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmbulancePCR.WebMVC.Startup))]
namespace AmbulancePCR.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
