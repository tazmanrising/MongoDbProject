using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JobManager.Models;
using JobManager.Services;
using Umbraco.Web.WebApi;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace JobManager.Controllers.APIs
{
    //[RoutePrefix("api/ActivityApi")]
    public class ActivityApiController : UmbracoApiController
    {

        [Route("GetActivityByMemberId")]
        [HttpGet]
        public IHttpActionResult GetActivityByMemberId(int id)
        {
            var activityList = ActivityService.GetRecentActivities().ToList();



            return Ok(activityList);


            //return null;
        }

        //todo:  create method passing in clientid  

        //[Route("GetActivityByClientShortCode")]
        //[ResponseType(typeof(Activity))]
        [HttpGet]
        public HttpResponseMessage GetActivityByClientShortCode(string id)
        {

            // 1. USE this method for my current service call  
            // 2. e.g.  ACME 
            // 3. Order by date desc  
            // a. finish these api controller methods
            // b. finish angular service functions  
            // c.  do split that save into a update and create 
            // d. steve will do directives - 
            // Orders call activities    put this off   ...
            // todo  :    Next Order/Job Number:ACME-1   fix it 
            // todo:  put these notes into jira   
            //  ACME  
            //http://localhost:49810/clients/#/detail/1117
            // see all activities for a particular client  
            // sample data 

            HttpResponseMessage response;
            var activityList = ActivityService.GetActivitiesByShortCode(id.ToString());
            response = Request.CreateResponse(HttpStatusCode.OK, activityList.Reverse());

            return response;
        }

        


        [HttpPost]
        //public HttpResponseMessage GetActivityByOrderNumbers([FromUri] string[] id)
        public IHttpActionResult GetActivityByOrderNumbers(List<OrderStuff> orderStuff)
        {
            //IEnumerable<Models.OrderListViewItem> orders = Models.Order.ToListView(JobManager.Services.OrderService.GetRecentOrders());
            var activityList = ActivityService.GetActivitiesByOrderNumber(orderStuff).ToList();

            return Ok(activityList);
        }
        

        //[Route("get")]
        [HttpGet]
        public IHttpActionResult GetActivity()
        {
            var activityList = ActivityService.GetRecentActivities().ToList();
            return Ok(activityList);
        }

        //[Route("create")]
        [HttpPost]
        public IHttpActionResult CreateActivity(Activity activity)
        {
            // todo:  switch from IHttpActionResult to HttpResponseMessage


            IMember member = null; 

            try
            {
                // set token in header in postman ,  but logged into application
                // then it is fine 
                var memberService = ApplicationContext.Current.Services.MemberService;
                var memberId = Members.GetCurrentMember().Id;
                member = memberService.GetById(memberId);
                activity.CreatedById = memberId;
                activity.CreatedByName = member.Name;
            }
            catch (Exception exception)
            {

                string ex = exception.ToString();

            }
           

         

            var ret = ActivityService.CreateActivity(activity, member);
           return Ok(ret);
        }

        //[Route("update")]
        [HttpPost]
        public IHttpActionResult UpdateActivity(Activity activity)
        {

            IMember member = null;
            try
            {
                var memberService = ApplicationContext.Current.Services.MemberService;
                var memberId = Members.GetCurrentMember().Id;
                member = memberService.GetById(memberId);
                activity.UpdatedById = memberId;
                activity.UpdatedByName = member.Name;
            }
            catch (Exception exception)
            {

                string ex = exception.ToString();

            }



            var ret = ActivityService.CreateActivity(activity, member);
            return Ok(ret);
        }

        //[Route("delete")]
        [HttpPost]
        //public IHttpActionResult DeleteActivity([FromBody]string Id)
        public IHttpActionResult DeleteActivity(string Id)
        {
            var del = ActivityService.DeleteActivity(Id);
            return Ok(del);
        }


    }

    public class OrderStuff
    {
        public string id { get; set; }
    }


}
