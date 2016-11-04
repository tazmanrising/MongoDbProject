using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdminTester
{
    public static class OrderService
    {
        public static IEnumerable<Order> GetRecentOrders()
        {
            return OrdersStore.GetOrders();
        }

    }

}
