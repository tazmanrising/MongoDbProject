using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Security;
using Umbraco.Web.Security;
using Umbraco.Web.WebApi;

namespace MarketingTools.Controllers.Api
{
    public class OrderApiController : UmbracoApiController
    {
        public HttpResponseMessage GetMyOrders(string id)
        {
            var memberId = Members.GetCurrentMemberId();
            var currentMember = Members.GetById(memberId);
            var clientId = Utilities.GetString(currentMember.GetProperty("clientId").Value);

            var newObj = new Models.ClientView();
            
            //var memberService = ApplicationContext.Current.Services.MemberService;

            // var currentMember = membershipHelper.GetCurrentMember(ApplicationContext.Current);
            //var currentMember = ApplicationContext.Current.Services.MemberService;
            //Models.MemberProfileView member = new Models.MemberProfileView(currentMember);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
