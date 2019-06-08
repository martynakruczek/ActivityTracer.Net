namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdada : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Steps", "Day", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Steps", "Day", c => c.DateTime());
        }
    }
}
