using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCollaborationLib.Domain;

namespace MusicCollaborationLib.Repository
{
    public interface IArtistRepository
    {
        Artist Create(Artist artist);
        void Delete(int id);
        Artist GetArtist(int id);
        IEnumerable<Artist> GetArtists();
    }
}
