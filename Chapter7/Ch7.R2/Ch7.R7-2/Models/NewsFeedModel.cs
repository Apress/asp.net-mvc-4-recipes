using Ch7.SharedAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ch7.R7_2.Models
{
    public class NewsFeedModel
    {
        //public List<Alert> NewsFeed { get; set; }
        public IEnumerable<Alert> NewsFeed { get; set; }
        public string Message { get; set; }
    }
}