using Ch7.R7_2.Models;
using Ch7.SharedAPI;
using Ch7.SharedAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Ch7.R7_2.Controllers
{
    public class ArtistController : Controller
    {
        //
        // GET: /Artist/
        [Authorize(Roles = "Artist")]
        public ActionResult Index()
        {
            return View();
        }
        MobEntities m_context = new MobEntities();

        [ChildActionOnly]
        public ActionResult ArtistInfo()
        {
            ArtistInfoModel model = new ArtistInfoModel();
            int artistId = WebSecurity.CurrentUserId;
            try
            {

                var userDataCollection = from d in m_context.Artists
                                         where d.ArtistId == artistId
                                         select new
                                         {
                                             d.CreateDate,
                                             d.LastActivityDate,
                                             d.ProfileViews,
                                             d.Tasks,
                                             d.UserName,
                                             d.ProfileLastViewDate,
                                             d.AvatarURL
                                         };
                var userData = userDataCollection.FirstOrDefault();
                if (userData != null)
                {
                    model.AccountCreatedDate = userData.CreateDate;
                    model.ArtistName = userData.UserName;
                    model.ProfileLastViewedDate = userData.ProfileLastViewDate.Value;
                    model.ProfileBookmark = string.Concat(SharedConfig.ApplicationURL, "/", userData.UserName);
                    model.ProfileViews = userData.ProfileViews;
                    model.AvatarURL = userData.AvatarURL;
                    model.PasswordLastChangedDate = WebSecurity.GetPasswordChangedDate(WebSecurity.CurrentUserName);
                }
                else
                {
                    return PartialView("_NoDataPartial", "Artist not found.");

                }

            }
            catch (Exception )
            {
                //TODO: Log exception
                return PartialView("_NoDataPartial", "Error occured.");
            }
            return PartialView("_ArtistInfoPartial",model);
        }

        [ChildActionOnly]
        public ActionResult NewsFeed()
        {

            NewsFeedModel model = new NewsFeedModel();
            int artistId = WebSecurity.CurrentUserId;
            try
            {

                var obj = m_context.GetUserAlerts(artistId);
                if (obj != null )
                {
                    model.NewsFeed = obj.ToList();
                }
                if(model.NewsFeed.Count()==0)
                {
                    return PartialView("_NoDataPartial", "Sorry, we could not find any stories that match your interests.");
                }

            }
            catch
            {
                //TODO: Log exception
                return PartialView("_NoDataPartial", "Sorry could not access the data.");
            }
            return PartialView("_NewsFeedPartial", model);
        }
        
        [ChildActionOnly]
        public ActionResult SongCollaborationWorkspace()
        {
            SongCollaborationWorkspaceListModel model = new SongCollaborationWorkspaceListModel();
            int artistId = WebSecurity.CurrentUserId;
            try
            {

                var workspaces = from w in m_context.ArtistCollaborationSpaces.Where(e => e.ArtistId == artistId)
                                 select w.CollaborationSpace;
                if (workspaces != null && workspaces.Count() > 0)
                {
                    model.NumberofMatchingWorkspaces = workspaces.Count();
                    model.CollaborationSpaces = workspaces.ToList();

                }
                else
                {
                    return PartialView("_NoDataPartial", "No workspaces found.");
                }

            }
            catch
            {
                //TODO log error
                return PartialView("_NoDataPartial", "An error occured.");
            }
            return PartialView("_SongCollaborationWorkspacePartial",model);
        }

        [ChildActionOnly]
        public ActionResult SongPlaylist()
        {
            SongPlaylistModel model = new SongPlaylistModel();
            int artistId = WebSecurity.CurrentUserId;
            try
            {
                var playlistitems = from a in m_context.PlaylistItems
                                    where (a.PlayList.ArtistId == artistId)
                                    && (a.PlayList.IsDefaultPlaylist == true)
                                    orderby a.DisplayOrder
                                    select a;
                if (null != playlistitems && playlistitems.Count() > 0)
                {
                    model.ArtistSongs = playlistitems.ToList();
                    model.NumberofMatchingSongs = playlistitems.Count();

                }
                else
                {
                    return PartialView("_NoDataPartial", "No songs found.");
                }

            }
            catch
            {
                //TODO log error
                return PartialView("_NoDataPartial", "An error occured.");
            }
            return PartialView("_SongPlaylistPartial",model);
        }

        protected override void Dispose(bool disposing)
        {
            m_context.Dispose();
            base.Dispose(disposing);
        }

    }
}
