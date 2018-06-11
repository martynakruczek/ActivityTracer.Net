namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Duratin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workouts", "DateOfWorkout", c => c.DateTime());
            AlterColumn("dbo.Workouts", "Duration", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "Duration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Workouts", "DateOfWorkout", c => c.DateTime(nullable: false));
        }
    }
}
