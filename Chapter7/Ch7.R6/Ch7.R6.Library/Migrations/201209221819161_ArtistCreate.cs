namespace Ch7.R6.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtistCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Country = c.String(),
                        Provence = c.String(),
                        City = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        WebSite = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.ArtistSkills",
                c => new
                    {
                        ArtistSkillId = c.Int(nullable: false, identity: true),
                        TalentName = c.String(),
                        SkillLevel = c.Int(nullable: false),
                        Details = c.String(),
                        Styles = c.String(),
                        Artist_ArtistId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtistSkillId)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistId)
                .Index(t => t.Artist_ArtistId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ArtistSkills", new[] { "Artist_ArtistId" });
            DropForeignKey("dbo.ArtistSkills", "Artist_ArtistId", "dbo.Artists");
            DropTable("dbo.ArtistSkills");
            DropTable("dbo.Artists");
        }
    }
}
