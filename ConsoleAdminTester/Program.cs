using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdminTester
{
    class Program
    {
        static void Main(string[] args)
        {


            //[HttpGet]
            //public HttpResponseMessage GetRecentOrders()
            //{
            //    HttpResponseMessage response;
            //    IEnumerable<Models.OrderListViewItem> orders = Models.Order.ToListView(JobManager.Services.OrderService.GetRecentOrders());

            //    response = this.Request.CreateResponse(HttpStatusCode.OK, orders.Reverse());
            //    return response;
            //}

            try
            {
                IEnumerable<OrderListViewItem> orders = Order.ToListView(OrderService.GetRecentOrders());




                // ==========  ###  Create an Activity  ####  ===========================

                //var activity = new List<Activity>();
                //activity.Add(new Activity()
                //{
                //    ActivityType = "blah",
                //    Attachments = null,
                //    ClientName = "clientA",
                //    ClientShortCode = "A",
                //    CreatedById = 1,
                //    CreatedByName = "tom",
                //    CreatedDate = null,
                //    Description = "tom test",
                //    Id = null,
                //    OrderNumber = "thisorder",
                //    Status = "good",
                //    Title = "title here"

                //});

                var activity = new Activity();

                activity.ActivityType = "blah";
                activity.Attachments = null;
                activity.ClientName = "clientA";
                activity.ClientShortCode = "A";
                activity.CreatedById = 1;
                activity.CreatedByName = "tom";
                activity.CreatedDate = null; //DateTime.Now;
                activity.Description = "tom test";
                //activity.Id = "blah"; // null;
                activity.OrderNumber = "thisorder";
                //order.OrderNumber = JobManager.Services.ClientService.GetNextOrderId(Convert.ToInt32(model.ClientId));
                activity.Status = "good";
                activity.Title = "title here";

                //create (insert)
                var ret = ActivityService.CreateActivity(activity);
                //update 

                activity.Description = "tom update";
                //var retU = ActivityService.CreateActivity(activity);
                // read 

                // IEnumerable<Models.OrderListViewItem> orders = Models.Order.ToListView(JobManager.Services.OrderService.GetRecentOrders());

                var activityList = ActivityService.GetRecentActivities().ToList(); // GetActivitiesByOrderNumber());

                // delete

                //ObjectId("5807d09ab2ed627e747fe422")



                var del = ActivityService.DeleteActivity("blah");


                var x = "a";


            }
            catch (Exception exception)
            {

                var ex = exception.Message;

            }
        }

    }
}
