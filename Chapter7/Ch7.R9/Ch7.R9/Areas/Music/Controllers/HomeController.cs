using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch7.R9.Areas.Music.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Music/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
