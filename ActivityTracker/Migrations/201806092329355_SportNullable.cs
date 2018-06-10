namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SportNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workouts", "Sport", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "Sport", c => c.Int(nullable: false));
        }
    }
}
