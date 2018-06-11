namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Steps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfSteps = c.Int(nullable: false),
                        DailyCount = c.DateTime(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Steps", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Steps", new[] { "ApplicationUserID" });
            DropTable("dbo.Steps");
        }
    }
}
