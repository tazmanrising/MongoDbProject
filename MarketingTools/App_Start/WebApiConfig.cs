using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MarketingTools
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
        }
    }
}