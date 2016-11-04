using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JobManager.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //public ObjectId Id { get; set; }  // mongo object id
        public string OrderNumber { get; set; }  // unique id 
        public string ClientId { get; set; }
        public string CreatedByName { get; set; }     // Change Name to CreatedByName
        public string ClientName { get; set; }
        public string ClientShortCode { get; set; }
        public string Title { get; set; }  // Name of the Order   e.g.  they make it up, template at some point
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; } //DateCreated changed to CreatedDate change to
        public int CreatedById { get; set; }
        public string Status { get; set; }  // not req.  bus. logic will pop.
        public int AssignedToId { get; set; } // not req.
        public string AssignedToName { get; set; }
        public DateTime? AssignedToDate { get; set; }

        public List<Attachment> Attachments { get; set; }  // WILL need attachment object
           // attachments  not required  
        public DateTime? DueDate { get; set; }  // not required

        [BsonIgnore]
        List<Job> Jobs { get; set; } // not required 

        [BsonIgnore]
        List<PurchaseOrder> PurchaseOrders { get; set; }   // needs to change 

        //Hierarchy 
        
        // Orders will have multiple JOBS 
        // Will a PO span JOBS  
        // e.g.   PO span multiple jobs ?
        // single PO to span 

        //   PHP - 123 A , B, C 

        // Total = what we are buying them 

        // 


        public class Attachment
        {
            public string AttachmentType { get; set; }
        }
        



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

    public class Attachment
    {
        public string ClientFileId { get; set; }
        public string MimeType { get; set; }
        public string PublicPath { get; set; }
        public string FileName { get; set; }
    }


    public class ClientFile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }
        public string PublicPath { get; set; }
        public string FilePath { get; set; }
        public int Size { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int LastModifiedById { get; set; }
        public string LastModifiedByName { get; set; }
        public string Tags { get; set; }
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
        public string CreatedByName { get; set; }
        public string ClientName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public static implicit operator OrderListViewItem(Order modelIn)
        {
            OrderListViewItem modelOut = new OrderListViewItem();
            modelOut.Id = modelIn.Id.ToString();
            modelOut.OrderNumber = modelIn.OrderNumber;
            modelOut.CreatedByName = modelIn.CreatedByName;
            modelOut.ClientName = modelIn.ClientName;
            modelOut.Title = modelIn.Title;
            modelOut.Description = modelIn.Description;
            modelOut.Status = modelIn.Status;

            return modelOut;
        }
    }
}