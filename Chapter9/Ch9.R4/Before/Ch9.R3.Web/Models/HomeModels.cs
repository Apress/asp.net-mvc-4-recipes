using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Ch9.R3.Web.Models
{

    public class NewsItemOfTheDay
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public int NewsItemId { get; set; }
    }
}