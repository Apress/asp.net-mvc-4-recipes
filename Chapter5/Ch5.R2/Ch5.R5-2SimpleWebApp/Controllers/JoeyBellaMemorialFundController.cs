using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch5.R5_2SimpleWebApp.Controllers
{
    public class JoeyBellaMemorialFundController : Controller
    {
        //
        // GET: /JoeyBellaMemorialFund/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /JoeyBellaMemorialFund/TrickyTray

        public ActionResult TrickyTray()
        {
            return View();
        }

        //
        // GET: /JoeyBellaMemorialFund/BeefSteakDinner

        public ActionResult BeefSteakDinner()
        {
            return View();
        }

    }
}
