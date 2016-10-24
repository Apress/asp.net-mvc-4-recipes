using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ch7.R7_2.Models
{
    public class ArtistInfoModel
    {
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

        [Display(Name = "ArtistName")]
        public string ArtistName { get; set; }

    }
}