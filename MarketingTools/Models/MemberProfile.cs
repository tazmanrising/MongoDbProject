using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketingTools.Models
{
    public class MemberProfile
    {
    }

    public class MemberProfileView
    {
        public string Name { get; set; }
        public int MemberId { get; set; }
        public string ProfilePicUrl { get; set; }
        public string ClientCode { get; set; }
        public string ClientId { get; set; }

        public MemberProfileView() {}

        public MemberProfileView(Umbraco.Core.Models.IPublishedContent uMember)
        {
            Name = uMember.Name;
            MemberId = uMember.Id;

            ClientCode = (uMember.GetProperty("clientCode").HasValue)
                ? uMember.GetProperty("clientCode").Value.ToString() : "";
            ClientId = (uMember.GetProperty("clientId").HasValue)
                ? uMember.GetProperty("clientId").Value.ToString() : "";

            ProfilePicUrl = Utilities.GetImageUrl(uMember, "profilePic", "square");
        }

    }
}