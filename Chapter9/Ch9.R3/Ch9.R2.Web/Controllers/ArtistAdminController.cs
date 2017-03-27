using Ch7.SharedAPI;
using Ch9.R2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch9.R2.Web.Controllers
{
    public class ArtistAdminController : Controller
    {
        IArtistRepository m_repository;
        public ArtistAdminController() : this(new SharedAPIArtistRepository()) { }
        public ArtistAdminController(IArtistRepository repository)
        {
            m_repository = repository;
        }

        //
        // GET: /ArtistAdmin/List
        public ActionResult List()
        {
            List<Artist> artists = m_repository.GetNewArtistList() as List<Artist>;
            if (artists == null || artists.Count == 0)
            {
                ViewBag.Message = "No New Artists Found";
            }
            ViewResult result = new ViewResult();

            return View("List", artists);
        }

    }
}
