using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobManager.Controllers.APIs;
using JobManager.DAL.MongoDBService.Stores;
using JobManager.Models;
using MongoDB.Driver;
using JobManager.DAL.MongoDBService;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace JobManager.Services
{
    public static class ActivityService
    {

        private static IMongoCollection<Activity> _collection;

        private static IMongoCollection<Activity> Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = MongoDBRepository.Database.GetCollection<Activity>("Activities");

                }

                return _collection;
            }
        }

        public static IEnumerable<Activity> GetRecentActivities()
        {
            return ActivityStore.GetActivities();
        }

        public static IEnumerable<Activity> GetActivitiesByOrderNumber(List<OrderStuff> orders)
        {
            return ActivityStore.GetActivitiesByOrderNumber(orders).ToList();
        }

        public static IEnumerable<Activity> GetActivitiesByShortCode(string clientShortCode)
        {
            IEnumerable<Activity> activities = ActivityStore.GetActivitiesByClientShortCode(clientShortCode)
                                                    .OrderByDescending((o => o.OrderNumber));
            return activities;
        }


        public static string CreateActivity(Activity activity, object member)
        {

            // getcurrentmember   need their id , and name  for created 
            // getclientbyid    client name  


            //var memberService = ApplicationContext.Current.Services.MemberService;
            //var memberId = Members.GetCurrentMember().Id;
            //var member = memberService.GetById(memberId);


            string activityResult;

            Activity newOrder = Collection.Find<Activity>(o => o.Id == activity.Id).SingleOrDefault<Activity>();
            if (newOrder == null)
            {
                activity.Status = "Created";
                activity.CreatedDate = DateTime.Now;
                activityResult = ActivityStore.Create(activity);

            }
            else
            {
                activity.UpdatedDate = DateTime.Now;
                activityResult = ActivityStore.Update(activity);
            }

            return activityResult;

            //string newActivity = ActivityStore.Save(activity);
            //return newActivity;


        }

        public static bool DeleteActivity(string activity)
        {

            var deleteActivity = ActivityStore.Delete(activity);
            return deleteActivity;
        }



    }

}