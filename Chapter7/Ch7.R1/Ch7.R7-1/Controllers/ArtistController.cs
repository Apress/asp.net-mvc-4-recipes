using Ch7.R7_1.Models;
using Ch7.SharedAPI;
using Ch7.SharedAPI.Abstract;
using Ch7.SharedAPI.Concrete;
using Ch7.SharedAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Ch7.R7_1.Controllers
{
    public class ArtistController : Controller
    {
        MobEntities m_context = new MobEntities();
        //
        // GET: /Artist/
        [Authorize(Roles="Artist")]
        public ActionResult Index()
        {
            ArtistDashboardModel model = new ArtistDashboardModel();
            try
            {
                int artistId = WebSecurity.CurrentUserId;
                var userDataCollection = from d in m_context.Artists
                                         where d.ArtistId == artistId
                                         select new
                                         {
                                             d.CreateDate,
                                             d.LastActivityDate,
                                             d.Messages.Count
                                             ,
                                             d.ProfileViews,
                                             d.Tasks
                                             ,
                                             d.UserName,
                                             d.ProfileLastViewDate,
                                             d.AvatarURL
                                             ,
                                             defualtPlaylist = d.PlayLists.Where(p => p.IsDefaultPlaylist == true)
                                         };
                var userData = userDataCollection.FirstOrDefault();

                var workspaces = from w in m_context.ArtistCollaborationSpaces.Where(e => e.ArtistId == artistId)
                                 select w.CollaborationSpace;

                model.AccountCreatedDate = userData.CreateDate;
                model.ArtistName = userData.UserName;
                model.PasswordLastChangedDate = WebSecurity.GetPasswordChangedDate(WebSecurity.CurrentUserName);
                model.ProfileLastViewedDate = userData.ProfileLastViewDate.Value;
                model.ProfileBookmark = string.Concat(SharedConfig.ApplicationURL, "/", userData.UserName);
                model.ProfileViews = userData.ProfileViews;
                model.AvatarURL = userData.AvatarURL;
                model.NewsFeed = m_context.GetUserAlerts(artistId).ToList();
                model.Tasks = userData.Tasks.ToList();
                model.CollaborationSpaces = workspaces.ToList();
                model.ArtistSongs = userData.defualtPlaylist.FirstOrDefault().PlaylistItems.ToList();
            }
            catch (Exception e)
            {
                model.ErrorMessage = "Sorry. Something dreadful has occured. Please accept our sincerest apology.";
            }

            return View(model);
        }


        protected override void Dispose(bool disposing)
        {
            m_context.Dispose();
            base.Dispose(disposing);
        }

    }
}
