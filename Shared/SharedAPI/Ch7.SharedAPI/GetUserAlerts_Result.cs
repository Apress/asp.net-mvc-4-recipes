//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ch7.SharedAPI
{
    using System;
    
    public partial class GetUserAlerts_Result
    {
        public int AlertId { get; set; }
        public string Headline { get; set; }
        public string Summary { get; set; }
        public int ArtistId { get; set; }
        public string ActorDisplayName { get; set; }
        public string ActorUrl { get; set; }
        public string ActorAvatarUrl { get; set; }
        public string AlertUrl { get; set; }
        public System.DateTime AlertAddedDate { get; set; }
        public int ClickCount { get; set; }
        public System.DateTime AlertDate { get; set; }
        public int Category { get; set; }
        public string ItemIdentifier { get; set; }
        public int ItemDetailIdentifier { get; set; }
    }
}
