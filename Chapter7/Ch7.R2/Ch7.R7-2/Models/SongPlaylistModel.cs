using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Ch7.R7_2.Models
{
    public class SongPlaylistModel
    {
        [Display(Name = "Number of Songs Found: ")]
        public int NumberofMatchingSongs { get; set; }
        public List<PlaylistItem> ArtistSongs { get; set; }
    }
}