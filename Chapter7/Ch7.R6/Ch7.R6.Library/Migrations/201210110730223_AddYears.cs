namespace Ch7.R6.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYears : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtistSkills", "YearsExperience", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArtistSkills", "YearsExperience");
        }
    }
}
