using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4NetTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                int n=int.Parse("aaa");
            }
            catch (Exception ex)
            {
                ex.WriteLog(Log4NetName.Log4NetTest);
            }
            return View();
        }

      
    }
}