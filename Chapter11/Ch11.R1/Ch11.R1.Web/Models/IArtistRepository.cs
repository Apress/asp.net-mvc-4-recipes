using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch11.R1.Web.Models
{
    public interface IArtistRepository : IDisposable
    {
        IList<Artist> GetNewArtists();
    }
}