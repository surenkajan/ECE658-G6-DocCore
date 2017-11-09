using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UoW.DocCore.Web.WebForms.Startup))]
namespace UoW.DocCore.Web.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
