using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using JobManager.Models;
using Umbraco.Core.Models;
using Umbraco.Web.WebApi;
using Umbraco.Core;

namespace JobManager.Controllers.APIs
{
    public class OrdersApiController : UmbracoApiController
    {
        // GET: api/DocStore
        [HttpGet]
        public string[] Get()
        {
            //MongoDBService.Stores.Collections.GetCollections();
            return new string[] { "value1", "value2" };
        }

        //[HttpGet]
        //public HttpResponseMessage GetCollections()
        //{
        //    var collections = DAL.MongoDBService.Stores.CollectionsStore.GetCollections();

        //    var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //    response.Content = new StringContent(collections, Encoding.UTF8, "application/json");
        //    return response;
        //}

        //[HttpGet]
        //public HttpResponseMessage GetAllDocuments()
        //{
        //    var model = DAL.MongoDBService.Stores.DocStore.GetAllDocuments();
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
        //    return response;
        //}

        // GET: api/DocStore/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DocStore
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // Todo:  Look at notebook in backpack for all the notes on what Steve wants
        // todo:   transfer and write up notes and code notes in orders etc. into jira 
        // todo:   create 4 cruds for orders,  including the several types of GETS per notebook notes 

        // todo  refactor orders and test all the  operations    
        // todo  controller methods  service to store level 
        // todo  keep the new job controller and po controller methods actually in this OrderController 


        [HttpGet]
        public HttpResponseMessage GetOrdersById(string id)
        {
            IEnumerable<OrderListViewItem> orders = Order.ToListView(JobManager.Services.OrderService.GetOrdersByShortCode(id));
            string ordersJson = orders.ToJson();
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(ordersJson, Encoding.UTF8, "application/json");
            return response;
        }



        [HttpGet]
        public HttpResponseMessage GetRecentOrders()
        {
            HttpResponseMessage response;
            IEnumerable<Models.OrderListViewItem> orders = Order.ToListView(JobManager.Services.OrderService.GetRecentOrders());

            response = Request.CreateResponse(HttpStatusCode.OK, orders.Reverse());
            return response;
        }
   

        [HttpGet]
        public HttpResponseMessage GetOrders(string id)
        {
            HttpResponseMessage response;

            IEnumerable<OrderListViewItem> orders = Order.ToListView(JobManager.Services.OrderService.GetOrdersByShortCode(id));
            string ordersJSON = orders.ToJson();
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(ordersJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetOrdersListByClientCode(string id)
        {
            HttpResponseMessage response;

            IEnumerable<OrderListViewItem> orders = Order.ToListView(JobManager.Services.OrderService.GetOrdersByShortCode(id));
            string ordersJSON = orders.ToJson();
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(ordersJSON, Encoding.UTF8, "application/json");
            return response;
        }

        /*
     
            GetByOrderNumber

            GetByAssigned 

            GetByUnassigned 

            GetByCreatedName

            GetByClientName 

            GetByClientId 

            GetByClientShortCode 


         */

        [HttpGet]
        public HttpResponseMessage GetByAssigned()
        {

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

            try
            {
                //IEnumerable<Activity> activities = ActivityStore.GetActivitiesByClientShortCode(clientShortCode)
                //                                  .OrderByDescending((o => o.OrderNumber));


                //var deleteOrderResult = JobManager.Services.OrderService.GetOrdersByAssigned();


                var ordersByAssignedResult = JobManager.Services.OrderService.GetOrderByAssigned();


                if (true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ordersByAssignedResult);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Order Not Found");
                }
            }
            catch (Exception ex)
            {
                // Log exception code goes here  
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while  Get assigned Order");
            }

        }
        

        [HttpGet]
        public HttpResponseMessage GetByUnAssigned()
        {

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

            try
            {
                //IEnumerable<Activity> activities = ActivityStore.GetActivitiesByClientShortCode(clientShortCode)
                //                                  .OrderByDescending((o => o.OrderNumber));
               //var deleteOrderResult = JobManager.Services.OrderService.GetOrdersByAssigned();

                var ordersByUnAssignedResult = JobManager.Services.OrderService.GetOrderByUnAssigned();


                if (true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ordersByUnAssignedResult);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Order Not Found");
                }
            }
            catch (Exception ex)
            {
                // Log exception code goes here  
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while Get Unassigned Order");
            }



        }


        [HttpPost]
        public HttpResponseMessage CreateFromAdmin([FromBody]OrderCreateView model)
        {
            HttpResponseMessage response;

            var memberId = Members.GetCurrentMemberId();
            
            if (model == null)
            {
                //model = new Models.Order();
                response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            }
            // Write the list to the response body.

            var order = new Order();

            order.Title = model.Title;
            order.Description = model.Description;
            order.ClientId = model.ClientId;
            order.ClientName = model.ClientName;
            order.ClientShortCode = model.ClientShortCode;

            order.CreatedDate = DateTime.Now;
            order.CreatedById = memberId;
            order.Status = "PENDING";
            order.OrderNumber = JobManager.Services.ClientService.GetNextOrderId(Convert.ToInt32(model.ClientId));

            JobManager.Services.OrderService.CreateOrder(order);

            response = Request.CreateResponse(HttpStatusCode.Created, order);

            return response;
        }

        [HttpPost]
        public HttpResponseMessage CreateFromClient(Models.Order model)
        {
            HttpResponseMessage response;

            JobManager.Services.OrderService.CreateOrder(model);
            response = Request.CreateResponse(HttpStatusCode.Created, model);

            return response;
        }

        #region update methods

        // PUT: api/DocStore/5
        [HttpPut]
        public HttpResponseMessage Put(Order model)
        {
            HttpResponseMessage response;

            response = Request.CreateResponse(HttpStatusCode.NotImplemented, model);

            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateOrder(Order model)
        {
            HttpResponseMessage response;

            JobManager.Services.OrderService.UpdateOrder(model);
            response = Request.CreateResponse(HttpStatusCode.OK, model);  // there is no Updated   Ok = 200   No Content = 204  

            return response;
        }

        #endregion
        
        // DELETE: api/DocStore/5
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(string id)
        {

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

            try
            {
                
                var deleteOrderResult = JobManager.Services.OrderService.DeleteOrder(id);

                if (true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, deleteOrderResult);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Order Not Found");
                }
            }
            catch (Exception ex)
            {
                // Log exception code goes here  
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while Deleting Order");  
            }
            
        }



        #region Jobs Controller Methods

        [HttpGet]
        public HttpResponseMessage CreateJob(Order order)
        {
            

            try
            {
                IMember member = null;
                var memberService = ApplicationContext.Current.Services.MemberService;
                var memberId = Members.GetCurrentMember().Id;
                member = memberService.GetById(memberId);

                var jobs = new Job();

                //jobs.

                //todo :   ask Steve about  for Jobs,  use OrderService or create JobService  etc..  ( store) 

                var ordersByUnAssignedResult = JobManager.Services.OrderService.GetOrderByUnAssigned();


                if (true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ordersByUnAssignedResult);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Order Not Found");
                }
            }
            catch (Exception ex)
            {
                // Log exception code goes here  
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while Get Unassigned Order");
            }



        }



        #endregion

    }
}