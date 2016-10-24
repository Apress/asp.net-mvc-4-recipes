using Ch10.Shared.Helpers;
using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ch11.R2.Web.Models
{
    public class EFAjaxDataGridRepository : IAjaxDataGridRepository
    {
        MobEntities m_context = new MobEntities();

        public IList<CollaborationSpaceSearchResult> GetActiveCollaborationSpaces(
            int page,
            int count,
            string sortExpression,
            out int resultsFound)
        {
            var collabSpacesQuery = from a in m_context.CollaborationSpaces
                                    join p in m_context.ArtistCollaborationSpaces
                                    on a.CollaborationSpaceId equals p.CollaborationSpaceId
                                    where a.Status != CollaborationSpaceStatus.Canceled &&
                                    a.Status != CollaborationSpaceStatus.OnHold &&
                                    a.Status != CollaborationSpaceStatus.Published &&
                                    a.AllowPublicView == true &&
                                    p.IsCreator == true
                                    select new CollaborationSpaceSearchResult()
                                    {
                                        CollaborationSpaceId = a.CollaborationSpaceId,
                                        CreateDate = a.CreateDate,
                                        Description = a.Description,
                                        LastPostDate = a.LastPostDate,
                                        ModifiedDate = a.ModifiedDate,
                                        NumberComments = a.NumberComments,
                                        NumberViews = a.NumberViews,
                                        RestrictContributorsToBand = a.RestrictContributorsToBand,
                                        Status = a.Status,
                                        Title = a.Title,
                                        UserName = p.Artist.UserName,
                                        WebSite = p.Artist.WebSite,
                                        AvatarURL = p.Artist.AvatarURL
                                    };


            resultsFound = collabSpacesQuery.Count();


            int skip = getSkip(page, count);
            if (String.IsNullOrEmpty(sortExpression))
            {
                sortExpression = "CreateDate";
            }
            collabSpacesQuery = collabSpacesQuery.OrderBy(sortExpression).Skip(skip).Take(count);

            return collabSpacesQuery.ToList<CollaborationSpaceSearchResult>();
        }

        private int getSkip(int page, int count)
        {
            if (page < 2)
            {
                return 0;
            }
            else
            {
                return page * count;
            }
        }

        ~EFAjaxDataGridRepository()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (m_context != null)
                    m_context.Dispose();
            }
        }
    }
}