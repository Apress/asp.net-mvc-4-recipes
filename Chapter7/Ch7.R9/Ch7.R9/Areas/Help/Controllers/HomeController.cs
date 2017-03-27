using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch7.R9.Areas.Help.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Help/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
