﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class MobEntities : DbContext
    {
        public MobEntities()
            : base("name=MobEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<AlertSubscription> AlertSubscriptions { get; set; }
        public DbSet<AlertTag> AlertTags { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistBand> ArtistBands { get; set; }
        public DbSet<ArtistBlock> ArtistBlocks { get; set; }
        public DbSet<ArtistCollaborationSpace> ArtistCollaborationSpaces { get; set; }
        public DbSet<ArtistFavorite> ArtistFavorites { get; set; }
        public DbSet<ArtistProfile> ArtistProfiles { get; set; }
        public DbSet<ArtistSkill> ArtistSkills { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<BandAudition> BandAuditions { get; set; }
        public DbSet<BandAuditionComment> BandAuditionComments { get; set; }
        public DbSet<BandGenre> BandGenres { get; set; }
        public DbSet<BannedEmailAddress> BannedEmailAddresses { get; set; }
        public DbSet<CollaborationSpace> CollaborationSpaces { get; set; }
        public DbSet<CollaborationSpaceAlert> CollaborationSpaceAlerts { get; set; }
        public DbSet<CollaborationSpaceComment> CollaborationSpaceComments { get; set; }
        public DbSet<CollaborationSpaceFile> CollaborationSpaceFiles { get; set; }
        public DbSet<CollaborationSpaceGenre> CollaborationSpaceGenres { get; set; }
        public DbSet<CollaborationSpaceInvite> CollaborationSpaceInvites { get; set; }
        public DbSet<CollaborationSpaceMedia> CollaborationSpaceMedias { get; set; }
        public DbSet<EmailOptOut> EmailOptOuts { get; set; }
        public DbSet<EmailVerification> EmailVerifications { get; set; }
        public DbSet<GenreLookUp> GenreLookUps { get; set; }
        public DbSet<Medium> Media { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageRecipient> MessageRecipients { get; set; }
        public DbSet<MessageSpam> MessageSpams { get; set; }
        public DbSet<OpenPosition> OpenPositions { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<PlaylistItem> PlaylistItems { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongComment> SongComments { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Membership> Membership { get; set; }
    
        public virtual int DeleteArtist(Nullable<int> artistId)
        {
            var artistIdParameter = artistId.HasValue ?
                new ObjectParameter("ArtistId", artistId) :
                new ObjectParameter("ArtistId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteArtist", artistIdParameter);
        }
    
        public virtual ObjectResult<Alert> GetUserAlerts(Nullable<int> artistId)
        {
            var artistIdParameter = artistId.HasValue ?
                new ObjectParameter("ArtistId", artistId) :
                new ObjectParameter("ArtistId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Alert>("GetUserAlerts", artistIdParameter);
        }
    
        public virtual ObjectResult<Alert> GetUserAlerts(Nullable<int> artistId, MergeOption mergeOption)
        {
            var artistIdParameter = artistId.HasValue ?
                new ObjectParameter("ArtistId", artistId) :
                new ObjectParameter("ArtistId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Alert>("GetUserAlerts", mergeOption, artistIdParameter);
        }
    }
}
