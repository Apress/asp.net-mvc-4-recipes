using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebFormsPageInspector.Models;

namespace WebFormsPageInspector.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var pizza = new Pizza("Extra Cheese");


            return View(pizza);
        }


        public ActionResult OneHundred()
        {
            var resultsArray = new List<String>();
            var template = "{0} is an {1} number.";
            bool ishalfDone = false;
            for (var i = 1; i < 101; i++)
            {
                if (i % 2 == 0)
                {
                    resultsArray.Add(string.Format(template, i,"even"));
                    if (i == 50)
                    {
                        resultsArray.Add(@"<div id=""HalfWay"">Keep going, we are half way done!</div>");
                        ishalfDone = true;
                    }
                }
                else
                {
                    resultsArray.Add(string.Format(template, i, "odd"));
                }
            }
            return View(resultsArray);
        }

    }
}
