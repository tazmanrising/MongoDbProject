using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JobManager.Models
{
    public class Activity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedById { get; set; }
        public string UpdatedByName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientShortCode { get; set; }
        public string OrderNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ActivityType { get; set; }
        public string Status { get; set; }
        public List<string> Attachments { get; set; }

        
        //TODO:   List of Actions and Inactions
        //     1. Activity
        //     2. Non-Activity
        //     3. Authentication attempts
        //     4. Authorization steps 
        //     5. CRUD operations
        //     6. Behavioral Patterns of uses.
        //     7. Security - any attempts to circumvent?
        //     8. Security - attempts for sql injection?
        //     9. Security - attempt for XSS?
        //     10. IP Address
        //     11. Browser 
        //     12. Other  - Bots , automation detection



    }
}