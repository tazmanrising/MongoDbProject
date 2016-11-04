using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using umbraco.BusinessLogic.Actions;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace JobManager.App_Plugins.MongoManager.backoffice
{
    [PluginController("mongodbmanager")]
    [Umbraco.Web.Trees.Tree("mongodbmanager", "MDBMCollectionsTree", "Collections", iconClosed: "icon-file-cabinet", iconOpen: "icon-file-cabinet")]
    public class CollectionsTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            var nodes = new TreeNodeCollection();
            var item = this.CreateTreeNode("dashboard", id, queryStrings, "My item", "icon-file-cabinet", true);
            nodes.Add(item);
            return nodes;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();
            menu.Items.Add<ActionNew>("Create New Collection");
            menu.Items.Add<ActionDelete>("Delete Collection");
            return menu;
        }
    }

    [PluginController("mongodbmanager")]
    [Umbraco.Web.Trees.Tree("mongodbmanager", "MDBMDefinitionsTree", "Document Definitions", iconClosed: "icon-file-cabinet")]
    public class DocumentDefinitionsTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            var nodes = new TreeNodeCollection();
            var item = this.CreateTreeNode("dashboard", id, queryStrings, "My item", "icon-truck", true);
            nodes.Add(item);
            return nodes;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();
            menu.DefaultMenuAlias = ActionNew.Instance.Alias;
            menu.Items.Add<ActionNew>("Create");
            menu.Items.Add<ActionDelete>("Delete");
            return menu;
        }
    }
}