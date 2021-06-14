using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTCSURVEYCMS.Startup))]
namespace PTCSURVEYCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
