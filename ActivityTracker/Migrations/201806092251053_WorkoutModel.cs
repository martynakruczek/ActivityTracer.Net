namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkoutModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Sport = c.Int(nullable: false),
                        DateOfWorkout = c.DateTime(nullable: false),
                        Duration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Workouts");
        }
    }
}
