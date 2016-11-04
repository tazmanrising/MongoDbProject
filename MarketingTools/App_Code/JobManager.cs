using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MarketingTools.JobManager
{
    public class JobManagerHelpers
    {
        public static Models.ClientView GetClientInfo(string clientId)
        {
            using (var client = new HttpClient())
            {
                // New code:
                var path = ConfigurationManager.AppSettings["JobManagerServer"].ToString() + "/Umbraco";
                client.BaseAddress = new Uri(path);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = client.GetAsync("Umbraco/Api/ClientsApi/GetClient/" + clientId).Result;
                if (response.IsSuccessStatusCode)
                {
                    Models.ClientView product = response.Content.ReadAsAsync<Models.ClientView>().Result;
                    return product;
                }


            }

            return null;
        }
    }
}