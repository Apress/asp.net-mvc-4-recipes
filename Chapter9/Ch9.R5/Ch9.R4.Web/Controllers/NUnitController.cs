﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch9.R4.Web.Controllers
{
    public class NUnitController : Controller
    {
        //
        // GET: /NUnit/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /NUnit/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /NUnit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NUnit/Create

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
        // GET: /NUnit/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /NUnit/Edit/5

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
        // GET: /NUnit/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /NUnit/Delete/5

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
