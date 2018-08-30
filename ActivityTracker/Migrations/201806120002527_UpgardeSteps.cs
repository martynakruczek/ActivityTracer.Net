namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgardeSteps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Steps", "Day", c => c.DateTime());
            AlterColumn("dbo.Steps", "NumberOfSteps", c => c.Int());
            DropColumn("dbo.Steps", "DailyCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Steps", "DailyCount", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Steps", "NumberOfSteps", c => c.Int(nullable: false));
            DropColumn("dbo.Steps", "Day");
        }
    }
}
