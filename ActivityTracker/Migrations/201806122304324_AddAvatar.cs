namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserAvatar", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserAvatar");
        }
    }
}
