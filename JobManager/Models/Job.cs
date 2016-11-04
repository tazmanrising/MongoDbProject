using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JobManager.Models
{
    public class Job
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  // mongo object id
        public string OrderNumber { get; set; }
        public string JobNumber { get; set; }  // OrderNumber-Alpha  e.g.   STARK-20-A  ,  -B , -C ...
        public List<LineItem> LineItems { get; set; } // not a mongo collection
        public DateTime? DueDate { get; set; }
        public string DeliveryType { get; set; }
        public decimal Tax { get; set; }
        public decimal SubTotal { get; set; }
        public bool Invoiced { get; set; }
        public bool Paid { get; set; }


    }

    // Job collection 

    // PurchaseOrder collection

    public class LineItem
    {
        public string ItemNumber { get; set; } // BC-12  ( business card -  stock inventory item 
        public int Quantity { get; set; } //
        public decimal Cost { get; set; }
        public decimal Price { get; set; }  // 64,000.00  needs handled   look up Double
        public decimal Markup { get; set; }
        public decimal Discount { get; set; }
        public string PONumber { get; set; }
        public string POStatus { get; set; }  // created , sent , complete, received, incomplete
        public bool IsTaxable { get; set; }
        public List<LineItem> LineItems { get; set; }  // json serializer  for recursion 

    }

    public class PurchaseOrder
    {
        // OrderNumber
        //JobNumber
        // Line Item 
        //  Price , isTaxable, desc cost  price, discount  , PONumber , POStatus, ItemId, Type   

        // create new purchase order in mongodb 

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal Price { get; set; }

    }
    
}