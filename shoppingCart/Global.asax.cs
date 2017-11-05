using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace shoppingCart
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
