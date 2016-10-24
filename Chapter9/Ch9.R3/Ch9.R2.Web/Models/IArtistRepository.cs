using Ch7.SharedAPI;
using System.Collections.Generic;

namespace Ch9.R2.Web.Models
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetNewArtistList();
        Artist GetArtistDetails(int id);
        void DeleteArtist(int id);
    }
}
