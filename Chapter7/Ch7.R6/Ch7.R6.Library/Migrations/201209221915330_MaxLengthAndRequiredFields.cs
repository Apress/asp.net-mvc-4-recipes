namespace Ch7.R6.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthAndRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Artists", "Country", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Artists", "Provence", c => c.String(maxLength: 65));
            AlterColumn("dbo.Artists", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Artists", "WebSite", c => c.String(maxLength: 255));
            AlterColumn("dbo.ArtistSkills", "TalentName", c => c.String(maxLength: 50));
            AlterColumn("dbo.ArtistSkills", "Details", c => c.String(maxLength: 500));
            AlterColumn("dbo.ArtistSkills", "Styles", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArtistSkills", "Styles", c => c.String());
            AlterColumn("dbo.ArtistSkills", "Details", c => c.String());
            AlterColumn("dbo.ArtistSkills", "TalentName", c => c.String());
            AlterColumn("dbo.Artists", "WebSite", c => c.String());
            AlterColumn("dbo.Artists", "City", c => c.String());
            AlterColumn("dbo.Artists", "Provence", c => c.String());
            AlterColumn("dbo.Artists", "Country", c => c.String());
            AlterColumn("dbo.Artists", "UserName", c => c.String());
        }
    }
}
