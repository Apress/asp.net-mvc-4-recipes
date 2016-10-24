using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIForLoadTest.Models
{
    public class PlaylistModel
    {
        private List<SongModel> m_Songs = null;
        public string PlayListName { get; set; }
        public List<SongModel> Songs
        {
            get
            {
                if (m_Songs == null) { m_Songs = new List<SongModel>(); }
                return m_Songs;
            }
            set { m_Songs = value; }
        }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class SongModel
    {
        public string Title { get; set; }
        public string AlbumName { get; set; }
        public ArtistModel SongArtist { get; set; }
        public int SongOrder { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class ArtistModel
    {
        public string ArtistName{get;set;}
        public string ArtistHomePageUrl{get;set;}
        public string ArtistThumbnailImageUrl { get; set; }
    }
}