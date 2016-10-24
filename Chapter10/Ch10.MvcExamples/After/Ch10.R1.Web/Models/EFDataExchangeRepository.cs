using Ch7.SharedAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ch10.Shared.Helpers;
using System.Data;

namespace Ch10.Mvc.Web.Models
{
    public class EFDataExchangeRepository : IDataExampleRepository
    {
        MobEntities m_context = new MobEntities();

        public List<Ch7.SharedAPI.Artist> GetNewArtistList()
        {
            //last 20 Artist records created
            var newArtistsQuery = (from m in m_context.Artists
                                   orderby m.CreateDate descending
                                   select m).Take(20);
            List<Artist> newArtistsList = newArtistsQuery.ToList<Artist>();
            return newArtistsList;
        }

        public Artist GetArtistDetails(int id)
        {
            return m_context.Artists.Find(id);
        }

        public IList<CollaborationSpaceSearchResult> GetActiveCollaborationSpaces(int page, int count, string sortExpression, int categoryId, bool sortDecending, out int resultsFound)
        {
            var collabSpacesQuery = from a in m_context.CollaborationSpaces
                                    join o in m_context.CollaborationSpaceGenres
                                    on a.CollaborationSpaceId equals o.CollaborationSpaceId
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
                                        Description= a.Description,
                                        LastPostDate= a.LastPostDate,
                                        ModifiedDate = a.ModifiedDate,
                                        NumberComments = a.NumberComments,
                                        NumberViews = a.NumberViews,
                                        RestrictContributorsToBand = a.RestrictContributorsToBand,
                                        Status = a.Status,
                                        Title = a.Title,
                                        GenreLookUpId = o.GenreLookUpId,
                                        UserName = p.Artist.UserName,
                                        WebSite = p.Artist.WebSite,
                                        AvatarURL = p.Artist.AvatarURL
                                    };
            if (categoryId > 0)
            {
                collabSpacesQuery = from a in collabSpacesQuery
                                    where a.GenreLookUpId == categoryId
                                    select a;
            }
            

            //get rid of duplicates and sort
            collabSpacesQuery = (from a in collabSpacesQuery
                                 group a by a.CollaborationSpaceId into u
                                 select u.FirstOrDefault());

            resultsFound = collabSpacesQuery.Count();

            

            int skip = getSkip(page, count);
            collabSpacesQuery = collabSpacesQuery.OrderBy( sortExpression).Skip(skip).Take(count);
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

        public IList<GenreLookUp> GetGenreLookupList()
        {
            var categories = from c in m_context.GenreLookUps
                             orderby c.GenreName
                             select c;
            return categories.ToList();
        }


        public List<ArtistSkill> GetArtistSkills(int artistId)
        {
            var skills = from c in m_context.ArtistSkills
                         where c.ArtistId == artistId
                         orderby c.ArtistTalentID descending
                         select c;
            return skills.ToList <ArtistSkill>();
        }
        public void UpdateSkill(ArtistSkill skill)
        {
            m_context.Entry(skill).State = EntityState.Modified;
            m_context.SaveChanges();
        }

        public void CreateSkill(ArtistSkill skill)
        {
            m_context.ArtistSkills.Add(skill);
            m_context.SaveChanges();
        }

        public void DeleteSkill(int artistSkillId)
        {
            ArtistSkill skill = m_context.ArtistSkills.Find(artistSkillId);
            if (skill != null)
            {
                m_context.ArtistSkills.Remove(skill);
                m_context.SaveChanges();
            }
        }

        public void Save()
        {
            m_context.SaveChanges();
        }

        public void CreateAds(OpenPositionsNeeded openPositionsNeeded)
        {
            //TODO
        }
        public void CreateCollaborationSpace(CollaborationSpace collaborationSpace)
        {
            //TODO
        }
        public void Dispose()
        {
            if (m_context != null)
                m_context.Dispose();
        }
    }
}