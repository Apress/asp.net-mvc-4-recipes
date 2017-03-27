using Ch10.Mvc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch10.Mvc.Web.Controllers
{
    public class DataExamplesController : Controller
    {

        public DataExamplesController(IDataExampleRepository repository)
        {
        }

        //
        // GET: /DataExamples/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RepeaterReplacement()
        {
            return View();
        }

        public ActionResult DataListReplacement()
        {
            return View();
        }

        public ActionResult GridViewReplacementWithSortFilterAndPaging()
        {
            return View();
        }

        public ActionResult GridViewReplacementWithInplaceEditing()
        {
            return View();
        }

        public ActionResult MasterDetailsView()
        {
            return View();
        }

    }
}
