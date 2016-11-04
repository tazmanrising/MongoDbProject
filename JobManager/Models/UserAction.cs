using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManager.Models
{
    public enum UseActions
    {
        GeneralSentMessage = 0,
        OrderCreated = 1,
        OrderUpdated = 2,
        OrderCompleted = 3,
        OrderCanceled = 4,

        FileUploaded = 10,
        FileDownloaded = 11,
        FileDeleted = 12
    }

    public class UserAction
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public UserActionUser Actor { get; set; }
        public UseActions Action { get; set; }
        public string Message { get; set; }
        public string ItemId { get; set; }
        public List<string> FileURIs { get; set; }
    }

    public class UserActionUser
    {
        public string Username { get; set; }
        public string UserFullname { get; set; }
        public string MemberId { get; set; }
        public string UserPicURL { get; set; }
    }
}