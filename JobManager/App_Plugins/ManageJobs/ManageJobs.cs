using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco;
using umbraco.businesslogic;
using umbraco.interfaces;

using umbraco.BusinessLogic.Actions;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace JobManager.App_Plugins.ManageJobs
{
    [Application("manageJobs", "Manage Jobs", "icon-truck", 10)]
    public class ManageJobs : IApplication
    {

    }

    [Umbraco.Web.Trees.Tree("manageJobs", "OrdersTree", "Orders")]
    [PluginController("ManageJobs")]
    public class OrdersController : TreeController
    {
        protected override Umbraco.Web.Models.Trees.TreeNodeCollection GetTreeNodes(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            throw new NotSupportedException();
        }

        protected override Umbraco.Web.Models.Trees.MenuItemCollection GetMenuForNode(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            //not worying about menu atm
            var menu = new MenuItemCollection();
            return menu;
        }
}

}