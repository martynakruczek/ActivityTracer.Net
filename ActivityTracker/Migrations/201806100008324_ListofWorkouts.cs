namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListofWorkouts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Workouts", "ApplicationUser_Id");
            AddForeignKey("dbo.Workouts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Workouts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Workouts", "ApplicationUser_Id");
        }
    }
}
