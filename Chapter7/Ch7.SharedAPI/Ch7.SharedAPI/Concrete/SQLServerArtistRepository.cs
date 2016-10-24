using Ch7.SharedAPI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch7.SharedAPI.Concrete
{
    public class SQLServerArtistRepository : IArtistRepository
    {

        private MobEntities m_ent = new MobEntities();
        public bool AutoSave { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_ent != null)
                {
                    m_ent.Dispose();
                    m_ent = null;
                }
            }
        }
        ~SQLServerArtistRepository() { Dispose(false); }

        
        /// <summary>
        /// Creates a new artist. You will need to call the SaveChanges method to preserve this data unless you have set the 
        /// AutoSave property to true
        /// </summary>
        /// <param name="artist">Valid artist object</param>
        public void Create(Artist artist)
        {
            if (artist != null)
            {
                m_ent.Artists.Add(artist);
                if (AutoSave)
                {
                    SaveChanges();
                }

            }
        }

        /// <summary>
        /// Saves changes to the DBContext. This should be called after any changes are made to the object
        /// </summary>
        public void SaveChanges()
        {
            m_ent.SaveChanges();
        }
        
        /// <summary>
        /// Deletes the artist and all assoicaited objects
        /// Uses a Function mapped stored procedure. Does not delete the assoiciated membership
        /// provider records. You do not need to call saveChanges after calling this method. 
        /// </summary>
        /// <param name="id">The ID of the artist that you would like to delete.</param>
        public void Delete(int id)
        {
            m_ent.DeleteArtist(id);
        }

        /// <summary>
        /// Gets all artists in the database or a subset based on additional
        /// Linq statements used later on. With Linq the query is not executed until
        /// the data is accessed, this allows for further filtering to occure
        /// </summary>
        /// <returns>An IQueryable<Artist> </returns>
        public IQueryable<Artist> GetArtists()
        {
            return m_ent.Artists;
        }

        /// <summary>
        /// Gets an artist specified by an ID
        /// </summary>
        /// <param name="id">ID number of the artist</param>
        /// <returns>Will return an Entity type of Artist or null if the artist is not found</returns>
        public Artist GetArtist(int id)
        {
            return m_ent.Artists.Find(id);
        }
    }
}
