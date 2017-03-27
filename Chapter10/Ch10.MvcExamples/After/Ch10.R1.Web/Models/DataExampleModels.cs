using Ch7.SharedAPI;
using System;
using System.Collections.Generic;

namespace Ch10.Mvc.Web.Models
{

    public class CollaborationSpaceSearchResult
    {
        public int CollaborationSpaceId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public DateTime ? LastPostDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int NumberComments { get; set; }
        public int NumberViews { get; set; }
        public bool RestrictContributorsToBand { get; set; }
        public CollaborationSpaceStatus Status { get; set; }
        public string Title { get; set; }
        public int GenreLookUpId { get; set; }
        public string UserName { get; set; }
        public string WebSite { get; set; }
        public string AvatarURL { get; set; }

    }
    public class CollaborationSpaceSearchResultModel
    {
        public IList<CollaborationSpaceSearchResult> CollaborationSpaceSearchResults { get; set; }
        public IList<GenreLookUp> GenreLookUpList { get; set; }
        public int NumberOfResults{get;set;}
        public string ResultsDescription { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string SortExpression { get; set; }
        public int CategoryId { get; set; }
        public int TotalPages
        {
            get
            {
                if (ItemsPerPage != 0)
                {
                    return NumberOfResults / ItemsPerPage;
                }
                return 0;
            }
        }
    }
}