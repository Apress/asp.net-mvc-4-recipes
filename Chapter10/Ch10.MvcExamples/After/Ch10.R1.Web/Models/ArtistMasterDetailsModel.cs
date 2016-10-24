using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch10.Mvc.Web.Models
{
    public class ArtistMasterDetailsModel
    {
        public Artist SelectedArtist { get; set; }
        public int SelectedArtistId { get; set; }

        public List<Artist> ArtistList { get; set; }
    }
}