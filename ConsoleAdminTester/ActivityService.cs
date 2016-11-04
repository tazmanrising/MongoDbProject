using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdminTester
{
    public static class ActivityService
    {

        public static IEnumerable<Activity> GetRecentActivities()
        {
            return ActivityStore.GetActivities();
        }

        public static IEnumerable<Activity> GetActivitiesByOrderNumber(string orderId)
        {
            return ActivityStore.GetActivitiesByOrderNumber(orderId).ToList();
        }




        public static string CreateActivity(Activity activity)
        {
            string newActivity = ActivityStore.Save(activity);
            return newActivity;
        }

        public static bool DeleteActivity(string activity)
        {

            var del = ActivityStore.Delete(activity);

            return del;
        }



    }
}
