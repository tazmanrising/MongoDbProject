using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManager.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientShortCode { get; set; }
        public string UploadFileRoot { get; set; }
        public string ProjectFileRoot { get; set; }
    }
}