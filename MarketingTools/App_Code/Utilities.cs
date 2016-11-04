using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

public static class Utilities
{
    public static string GetString(object obj)
    {
        return (obj != null) ? obj.ToString() : "";
    }

    public static string GetImageUrl(IPublishedContent content, string property, string crop)
    {
        var umbracoHelper = new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current);

        var profile = umbracoHelper.TypedMember(content.Id);
        var profilePic = profile.GetCropUrl("profilePic", "profile-square");
        return profilePic;
    }
}