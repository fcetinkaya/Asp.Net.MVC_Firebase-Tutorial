using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspnetMVC_FirebaseTutorial
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            //AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
            //AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;
            //AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimsIdentity.DefaultNameClaimType;
        }
    }
}
