using Ch9.R8.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ch9.R8.Web.Controllers
{
    public class ArchitectController : Controller
    {
        //using a repository rather the Entity Framework
        private IArchitectRepository m_Repository;

        //this constructor is required for testing
        public ArchitectController(IArchitectRepository respository)
        {
            m_Repository = respository;
        }

        //constructor required by MVC Framework
        // uses the EFArchitectRepository as the default controller
        public ArchitectController() : this(new EFArchitectRepository()){}

        //
        // GET: /Architect/

        public ActionResult Index()
        {
            List<Architect> architects = m_Repository.GetArchitectList();
            if (architects != null)
            {
                if (architects.Count < 1)
                {
                    ViewBag.NoDataFoundMessage = "No architects found.";
                }
                else
                {
                    ViewBag.NumberFoundMessage = string.Format("{0} architects found.", architects.Count);
                }
            }
            return View("Index",architects);
        }

        //
        // GET: /Architect/Details/5

        public ActionResult Details(int id = 0)
        {
            Architect architect = m_Repository.GetArchitectDetails(id);
            if (architect == null)
            {
                return HttpNotFound();
            }
            return View(architect);
        }

        //
        // GET: /Architect/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Architect/Create

        [HttpPost]
        public ActionResult Create(Architect architect)
        {
            if (ModelState.IsValid)
            {
                m_Repository.Create(architect);
                m_Repository.Save();
                return RedirectToAction("Index");
            }

            return View("Create", architect);
        }

        //
        // GET: /Architect/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Architect architect = m_Repository.GetArchitectDetails(id);
            if (architect == null)
            {
                return HttpNotFound();
            }
            return View(architect);
        }

        //
        // POST: /Architect/Edit/5

        [HttpPost]
        public ActionResult Edit(Architect architect)
        {
            if (ModelState.IsValid)
            {
                m_Repository.Update(architect);
                m_Repository.Save();
                return RedirectToAction("Index");
            }
            return View(architect);
        }

        //
        // GET: /Architect/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Architect architect = m_Repository.GetArchitectDetails(id);
            if (architect == null)
            {
                return HttpNotFound();
            }
            return View(architect);
        }

        //
        // POST: /Architect/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            m_Repository.Delete(id);
            m_Repository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_Repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}