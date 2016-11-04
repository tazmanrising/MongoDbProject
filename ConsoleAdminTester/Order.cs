using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ConsoleAdminTester
{
    public class Order
    {
        public ObjectId Id { get; set; }
        public string OrderNumber { get; set; }
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string ClientShortCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public int CreatedById { get; set; }
        public string Status { get; set; }

        public static explicit operator Order(OrderListViewItem model)
        {
            Order modelOut = new Order();

            return modelOut;
        }

        public static IEnumerable<OrderListViewItem> ToListView(IEnumerable<Order> orderList)
        {
            List<OrderListViewItem> orderViewList = new List<OrderListViewItem>();

            foreach (Order order in orderList)
            {
                orderViewList.Add(order);
            }

            return orderViewList;
        }
    }

    public class OrderCreateView
    {
        public string ClientId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string ClientShortCode { get; set; }
        public DateTime? DueDate { get; set; }
        public bool GenerateOrderId { get; set; }
        public bool? CreateInitialJob { get; set; }
    }

    public class OrderListViewItem
    {

        public string Id { get; set; }
        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public static implicit operator OrderListViewItem(Order modelIn)
        {
            OrderListViewItem modelOut = new OrderListViewItem();
            modelOut.Id = modelIn.Id.ToString();
            modelOut.OrderNumber = modelIn.OrderNumber;
            modelOut.Name = modelIn.Name;
            modelOut.ClientName = modelIn.ClientName;
            modelOut.Title = modelIn.Title;
            modelOut.Description = modelIn.Description;
            modelOut.Status = modelIn.Status;

            return modelOut;
        }
    }
}
