using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch11.R1.Web.Models
{
    public class EFArtistRepository : IArtistRepository
    {
        private MobEntities m_context = new MobEntities();
        public IList<Artist> GetNewArtists()
        {
            var results = (from a in m_context.Artists
                           where a.ProfilePrivacyLevel == 0
                           orderby a.CreateDate descending
                           select a).Take(40);
            return results.ToList<Artist>();
        }

        public void Dispose()
        {
            if (m_context != null)
                m_context.Dispose();
        }
    }
}