using Ch10.Mvc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch10.Mvc.Web.Controllers
{
    public class FormsController : Controller
    {
        //
        // GET: /Forms/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CustomValidationModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SuccessMessage = "The form is valid";
            }
            else
            {
                ViewBag.SuccessMessage = "The form is not valid";
            }
            return View("Index", model);
        }

        public ActionResult NestedLayout()
        {
            return View();
        }


    }
}
