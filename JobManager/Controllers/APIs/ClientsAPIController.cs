using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using JobManager.Models;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace JobManager.Controllers.APIs
{
    public class ClientsAPIController : UmbracoApiController
    {
        [HttpGet]
        public IEnumerable<ClientView> GetAllActiveClients()
        {
            var clients = Services.ContentService.GetChildren(1091).Where(c => c.Published == true);
            var clientViewList = new List<ClientView>();
            foreach(IContent client in clients)
            {
                var cv = new ClientView();
                var currentContent = Umbraco.Content(client.Id);

                cv.Id = client.Id.ToString();
                cv.ClientCode = client.GetValue("clientCode").ToString();
                cv.ClientName = client.Name;
                if(client.GetValue("clientLogo") != null)
                {
                    var logoURL = currentContent.GetCropUrl("clientLogo", "square");
                    cv.LogoURL = logoURL;
                }

                cv.ContactName = Utilities.GetString(client.GetValue("contactName"));
                cv.ContactEmail = Utilities.GetString(client.GetValue("contactEmailAddress"));
                cv.ContactPhone = Utilities.GetString(client.GetValue("contactPhoneNumber"));

                clientViewList.Add(cv);
            }
            return clientViewList;
        }

        [HttpGet]
        public HttpResponseMessage GetClient(int id)
        {
            
            IContent client = Services.ContentService.GetById(id);
            var currentContent = Umbraco.Content(client.Id);

            var cv = new ClientView()
            {
                Id = client.Id.ToString(),
                ClientName = client.Name,
                ClientCode = client.GetValue("clientCode").ToString()
            };



            cv.NextJobNumber = Utilities.GetString(client.GetValue("nextJobNumber"));
            cv.IsSampleData = Utilities.GetString(client.GetValue("isSampleClient"));
            cv.ContactName = Utilities.GetString(client.GetValue("contactName"));
            cv.ContactEmail = Utilities.GetString(client.GetValue("contactEmailAddress"));
            cv.ContactPhone = Utilities.GetString(client.GetValue("contactPhoneNumber"));
            var componentValues = Utilities.GetString(client.GetValue("components"));

            //List<string> componentList = new List<string>();
            //foreach (var compVal in componentValues.Split(','))
            //{
            //    componentList.Add(umbraco.library.GetPreValueAsString(Convert.ToInt32(compVal)));
            //}
            //cv.Components = componentList.ToArray();

            if (client.GetValue("clientLogo") != null)
            {
                var logoURL = currentContent.GetCropUrl("clientLogo", "square");
                cv.LogoURL = logoURL;
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, cv);
            return response;
        }

        [HttpPost]
        public HttpResponseMessage UpdateClient([FromBody] ClientView model)
        {
            HttpResponseMessage response;

            var clientView = new ClientView();


            // Todo:   Save client profile to Umbraco 

            //var ret = ActivityService.CreateActivity(activity);
            // Ok(ret);

            
            IContent client = Services.ContentService.GetById(Convert.ToInt32(model.Id));
            var contentService = ApplicationContext.Current.Services.ContentService;
            client.SetValue("isSampleClient", model.IsSampleData);
            client.SetValue("contactName", model.ContactName);
            client.SetValue("contactEmailAddress", model.ContactEmail);
            client.SetValue("contactPhoneNumber", model.ContactPhone);
            //clientService.Save(client);  // UNPUBLISHES   while it saves 
            contentService.SaveAndPublishWithStatus(client, raiseEvents: false);


            //var d = Utilities.GetString(client.SetValue("isSampleClient",model.ContactEmail));


            response = Request.CreateResponse(HttpStatusCode.Created, clientView);
            return response;
        }



        [HttpPut]
        public HttpResponseMessage SelectClient(string id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound);

            var memberService = ApplicationContext.Current.Services.MemberService;
            var memberId = Members.GetCurrentMember().Id;
            var member = memberService.GetById(memberId);
            member.SetValue("lastClient", id);
            memberService.Save(member);

            var clientService = ApplicationContext.Current.Services.ContentService;
            var client = clientService.GetById(Convert.ToInt32(id));
            if(client != null)
            { 

            ClientView cv = new ClientView();
            cv.ClientName = client.Name;
            cv.Id = client.Id.ToString();
            cv.ClientCode = Utilities.GetString(client.GetValue("clientCode"));

            response = Request.CreateResponse(HttpStatusCode.OK, cv);
            }
            return response;
        }

        [HttpGet]
        public IEnumerable<IContent> GetActiveNodes()
        {
            var clients = Services.ContentService.GetChildren(1091).Where(c => c.Published == true);
            return clients;
        }

    }
}