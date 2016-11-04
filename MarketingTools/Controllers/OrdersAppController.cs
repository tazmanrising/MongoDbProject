using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;

namespace MarketingTools.Controllers
{
    public class OrdersAppController : Umbraco.Web.Mvc.RenderMvcController
    {
        // GET: OrdersApp
        public override ActionResult Index(RenderModel model)
        {
            ViewBag.SomeVariable = "Hello World!";
            return base.Index(model);
        }
    }
}