using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch10.WebFormsExamples.Web.ObjectDataSources
{
    public class ExampleDataSource : IDisposable
    {
        MobEntities m_context = new MobEntities();

        public String ArtistName { get; set; }
        public List<Ch7.SharedAPI.Artist> GetNewArtistList()
        {
            //last 20 Artist records created
            var newArtistsQuery = (from m in m_context.Artists
                                   orderby m.CreateDate descending
                                   select m).Take(10);
            List<Artist> newArtistsList = newArtistsQuery.ToList<Artist>();
            return newArtistsList;
        }

        public Artist GetArtistDetails(int id)
        {
            return m_context.Artists.Find(id);
        }

        public void Dispose()
        {
            if (m_context != null)
                m_context.Dispose();
        }
    }
}