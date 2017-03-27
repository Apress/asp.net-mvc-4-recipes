using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch7.SharedAPI.Abstract
{
    public interface IArtistRepository : IDisposable
    {
        void Create(Artist artist);
        void Delete(int id);
        void SaveChanges();

        IQueryable<Artist> GetArtists();
        Artist GetArtist(int id);

        

    }
}
