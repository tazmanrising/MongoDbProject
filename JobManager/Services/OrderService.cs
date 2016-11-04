using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobManager.Models;
using JobManager.DAL.MongoDBService.Stores;

namespace JobManager.Services
{
    public static class OrderService
    {
        public static IEnumerable<Order> GetRecentOrders()
        {
            return OrdersStore.GetOrders();
        }

        public static Order GetOrderById(string orderId)
        {
            return OrdersStore.GetOrderById(orderId);
        }

        public static Order GetOrderByNumber(string orderNumber)
        {
            return OrdersStore.GetOrderByNumber(orderNumber);
        }

        public static IEnumerable<Order> GetOrdersByShortCode(string clientShortCode)
        {
            IEnumerable<Order> orders = OrdersStore.GetOrdersByClientShortCode(clientShortCode).OrderByDescending((o=>o.OrderNumber));
            return orders;
        }

        public static string GetOrdersByShortCodeJSON(string clientShortCode)
        {
            string ordersJSON = OrdersStore.GetOrdersByClientShortCodeJSON(clientShortCode);
            return ordersJSON;
        }

        public static string CreateOrder(Order order)
        {
            string newOrder = OrdersStore.Save(order);
            return newOrder;
        }

        public static string UpdateOrder(Order order)
        {
            string orderResult;
            orderResult = OrdersStore.Save(order);
            return orderResult;

        }

        public static bool DeleteOrder(string id)
        {

            var deleteOrder = OrdersStore.Delete(id);
            return deleteOrder;
        }

        public static IEnumerable<Order> GetOrderByAssigned()
        {
            IEnumerable<Order> orders = OrdersStore.GetOrderByAssigned();
            return orders;
        }

        public static IEnumerable<Order> GetOrderByUnAssigned()
        {
            IEnumerable<Order> orders = OrdersStore.GetOrderByUnAssigned();
            return orders;
        }
        

    }
    public class SimpleReduceResult<T>
    {
        public string Id { get; set; }

        public T value { get; set; }

        //call
        //var options = new MapReduceOptions<BsonDocument, SimpleReduceResult<int>>();
    }




}