using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Ch7.R7_1.Models
{
    /// <summary>
    ///  artist info including a news feed, personal messages alerts, a to do list, 
    ///  a list of songs exposed via an HTML based media player, and a list of collaboration spaces that 
    ///  the artist has either started or contributed to
    /// </summary>
    public class ArtistDashboardModel
    {
        
        public List<Alert> NewsFeed { get; set; }
        public List<CollaborationSpace> CollaborationSpaces { get; set; }
        public List<PlaylistItem> ArtistSongs { get; set; }
        public List<Task> Tasks { get; set; }

        [Display(Name = "Member Since")]
        public DateTime AccountCreatedDate { get; set; }

        [Display(Name = "Password last changed")]
        public DateTime PasswordLastChangedDate { get; set; }

        [Display(Name = "Profile Hits")]
        public long ProfileViews { get; set; }

        [Display(Name = "Profile Last Viewed")]
        public DateTime ProfileLastViewedDate { get; set; }

        [Display(Name = "Member Since")]
        public string ProfileBookmark { get; set; }

        public string AvatarURL { get; set; }

        public string ArtistName { get; set; }

        public string ErrorMessage { get; set; }

    }
}