namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkoutStartENd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "StartAt", c => c.DateTime());
            AddColumn("dbo.Workouts", "EndAt", c => c.DateTime());
            DropColumn("dbo.Workouts", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "Duration", c => c.DateTime());
            DropColumn("dbo.Workouts", "EndAt");
            DropColumn("dbo.Workouts", "StartAt");
        }
    }
}
