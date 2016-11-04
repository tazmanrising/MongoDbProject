using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketingTools.Models
{
    public class ClientView
    {
        public string Id { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string LogoURL { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int TotalOrders { get; set; }
        public string[] Components { get; set; }
        public DateTime? LastOrder { get; set; }
    }
}