using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Ch7.R8.Controllers
{
    public class MonitorController : Controller
    {
        //
        // GET: /Monitor/

        public ActionResult Index()
        {
            Thread.Sleep(5000);
            return View();
        }

    }
}
