namespace Ch11.R3.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "AppointmentDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.People", "WhenToMeet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "WhenToMeet", c => c.DateTime(nullable: false));
            DropColumn("dbo.People", "AppointmentDate");
        }
    }
}
