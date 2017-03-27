using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch9.R4.Web.Controllers
{
    public class XUnitDotNetController : Controller
    {
        //
        // GET: /XUnitDotNet/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /XUnitDotNet/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /XUnitDotNet/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /XUnitDotNet/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /XUnitDotNet/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /XUnitDotNet/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /XUnitDotNet/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /XUnitDotNet/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
