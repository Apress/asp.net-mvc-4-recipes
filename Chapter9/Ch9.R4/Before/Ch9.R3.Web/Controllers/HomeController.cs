using Ch9.R3.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch9.R3.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            NewsItemOfTheDay model = new NewsItemOfTheDay();
            model.Headline = "This is the news item";
            model.NewsItemId = 4;
            model.Summary = "This a summary of the news item";
            return View("Index",model);
        }

    }
}
