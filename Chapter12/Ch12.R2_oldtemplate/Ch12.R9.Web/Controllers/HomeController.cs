using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Mvc.Facebook.Attributes;
using Microsoft.AspNet.Mvc.Facebook.Models;
using Ch12.R9.Web.Models;

namespace Ch12.R9.Web.Controllers
{
    public class HomeController : Controller
    {
        [FacebookAuthorize(Permissions = "email")]
        public ActionResult Index(MyAppUser user, FacebookObjectList<MyAppUserFriend> userFriends)
        {
            ViewBag.Message = "Modify this template to jump-start your Facebook application using ASP.NET MVC.";

            ViewBag.User = user;
            ViewBag.Friends = userFriends.Take(5);

            return View();
        }
    }
}
