namespace Ch11.R3.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firsta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeopleIWouldLikeToMeetModels",
                c => new
                    {
                        PeopleIWouldLikeToMeetModelId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Why = c.String(nullable: false, maxLength: 150),
                        WhenToMeet = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PeopleIWouldLikeToMeetModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PeopleIWouldLikeToMeetModels");
        }
    }
}
