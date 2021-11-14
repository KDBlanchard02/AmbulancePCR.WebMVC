using AmbulancePCR.Data;
using AmbulancePCR.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var service = new RoleService();
            service.CreateAdmin();
            service.MakeMyUserAdmin();
        }
    }
}
