using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using Umbraco.Web.WebApi;

namespace MarketingTools.Controllers.Api
{
    public class CatalogApiController : UmbracoApiController
    {
        [HttpGet]
        public HttpResponseMessage GetCategories(string id)
        {
            HttpResponseMessage response;

            var catalogNode = Umbraco.Content(id);
            var categoryNodes = catalogNode.Children();
            var categoryList = new List<Models.Catalog.Category>();

            foreach(Umbraco.Web.Models.DynamicPublishedContent node in categoryNodes)
            {
                var category = new Models.Catalog.Category();
                category.Name = node.Name;
                category.NodeId = node.Id;

                categoryList.Add(category);

            }
            var json = new JavaScriptSerializer().Serialize(categoryList);
            response = this.Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

    }
}
