using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch7.R4.DAL;

namespace Ch7.R4.Controllers
{
    public class ArtistController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Artist/

        public ActionResult Index()
        {
            return View(db.ARTISTs.ToList());
        }

        //
        // GET: /Artist/Details/5

        public ActionResult Details(decimal id = 0)
        {
            ARTIST artist = db.ARTISTs.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // GET: /Artist/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artist/Create

        [HttpPost]
        public ActionResult Create(ARTIST artist)
        {
            if (ModelState.IsValid)
            {
                db.ARTISTs.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        //
        // GET: /Artist/Edit/5

        public ActionResult Edit(decimal id = 0)
        {
            ARTIST artist = db.ARTISTs.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artist/Edit/5

        [HttpPost]
        public ActionResult Edit(ARTIST artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //
        // GET: /Artist/Delete/5

        public ActionResult Delete(decimal id = 0)
        {
            ARTIST artist = db.ARTISTs.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artist/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ARTIST artist = db.ARTISTs.Find(id);
            db.ARTISTs.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}