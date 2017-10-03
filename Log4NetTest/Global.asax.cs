using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Log4NetTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();           
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //注册lognet
            var log4NetFileName = FilePath(ConfigurationManager.AppSettings["log4net"]);
            if (File.Exists(log4NetFileName))
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetFileName));
            }
        }
        private static string FilePath(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            return string.Format("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/'), name.TrimStart('\\', '/'));
        }

    }
}
