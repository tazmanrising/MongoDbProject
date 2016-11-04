using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.businesslogic;
using umbraco.interfaces;

namespace JobManager.App_Plugins.MongoManager.backoffice
{
    [Application("mongodbmanager", "MongoDB Manager", "icon-server-alt", 15)]
    public class CustomSectionApplication : IApplication { }
}