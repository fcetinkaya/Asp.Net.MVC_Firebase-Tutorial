using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AspnetMVC_FirebaseTutorial.App_Start.StartUp))]
namespace AspnetMVC_FirebaseTutorial.App_Start
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
