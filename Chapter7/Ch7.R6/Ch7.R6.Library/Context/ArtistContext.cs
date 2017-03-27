using Ch7.R6.Library.Entities;
using System.Data.Entity;

namespace Ch7.R6.Library.Context
{
    public class ArtistContext : DbContext
    {
        public ArtistContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistSkill> ArtistSkills { get; set; }
    }
}
