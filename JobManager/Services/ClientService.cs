using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace JobManager.Services
{
    public class ClientService
    {
        public static string GetNextOrderId(int id)
        {
            string result = "";

            var clientService = ApplicationContext.Current.Services.ContentService;
            var client = clientService.GetById(id);
            if (client != null)
            {
                var shortCode = Utilities.GetString(client.GetValue("clientCode"));
                var orderNumber = Utilities.GetString(client.GetValue("nextJobNumber"));

                if (orderNumber == string.Empty) orderNumber = "1";

                var newOrderNumber = Convert.ToInt32(orderNumber);
                result = shortCode + "-" + orderNumber;

                client.SetValue("nextJobNumber", ++newOrderNumber);
                clientService.Save(client);
                clientService.Publish(client);

            }

            return result;
        }
    }
}