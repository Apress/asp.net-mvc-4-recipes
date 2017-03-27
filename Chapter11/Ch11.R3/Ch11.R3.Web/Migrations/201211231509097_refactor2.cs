namespace Ch11.R3.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        WhenToMeet = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            DropTable("dbo.PeopleIWouldLikeToMeetModels");
        }
        
        public override void Down()
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
            
            DropTable("dbo.People");
        }
    }
}
