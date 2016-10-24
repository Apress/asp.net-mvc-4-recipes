using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ch9.R2.Web.Models
{
    public class SharedAPIArtistRepository : IArtistRepository, IDisposable
    {
        private MobEntities m_context;

        public void Dispose()
        {
            if (m_context != null)
            {
                m_context.Dispose();
            }
        }

        public SharedAPIArtistRepository()
        {
            m_context = new MobEntities();
        }

        public IEnumerable<Artist> GetNewArtistList()
        {
            //last 20 Artist records created
            var newArtists = (from m in m_context.Artists
                              orderby m.CreateDate descending
                              select m).Take(20);
            return newArtists.ToList<Artist>();
        }

        public Artist GetArtistDetails(int id)
        {
            var artist = m_context.Artists.Find(id);
            return artist;
        }

        public void DeleteArtist(int id)
        {
            m_context.DeleteArtist(id);
        }
    }
}