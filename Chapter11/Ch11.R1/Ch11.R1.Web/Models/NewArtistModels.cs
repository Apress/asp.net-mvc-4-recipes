using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch11.R1.Web.Models
{
    public class NewArtistModel
    {
        public IList<Artist> NewArtistList
        {
            get;
            set;
        }


        public int NumberOfArtistsFound
        {
            get
            {
                if (NewArtistList != null)
                {
                    return NewArtistList.Count;
                }
                return 0;
            }
        }

        public string NoArtistsMessage { get; set; }
        public bool ShowNoArtistMessage
        {
            get
            {
                return NumberOfArtistsFound <= 0;
            }
        }
    }
}