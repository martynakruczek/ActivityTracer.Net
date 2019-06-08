namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rawdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RawDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Int(),
                        Y = c.Int(),
                        Z = c.Int(),
                        Day = c.DateTime(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RawDatas", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.RawDatas", new[] { "ApplicationUserID" });
            DropTable("dbo.RawDatas");
        }
    }
}
