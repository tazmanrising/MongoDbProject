using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Core.Models;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.WebApi;


using System.Web;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace MarketingTools.Controllers
{
    public class MemberApiController : UmbracoApiController
    {
        [HttpGet]
        public HttpResponseMessage GetMember(int id)
        {
            var member = Members.GetById(1099);
            Models.MemberProfileView model = new Models.MemberProfileView(member);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
            
            return response;
        }
    }
}
