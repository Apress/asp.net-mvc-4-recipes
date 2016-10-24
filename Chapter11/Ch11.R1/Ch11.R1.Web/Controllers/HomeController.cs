using Ch11.R1.Web.Models;
using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch11.R1.Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IArtistRepository rep)
        {
            m_repository = rep;
        }
        public HomeController() : this (new EFArtistRepository()){}
        public ActionResult Index()
        {
            return View();
        }

        IArtistRepository m_repository;

        public ActionResult NewArtists()
        {
            IList<Artist> artists = m_repository.GetNewArtists();

            return View("NewArtists", artists);

        }
    }
}
