namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkoutwithId1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Workouts", name: "ApplicationUser_Id", newName: "ApplicationUserID");
            RenameIndex(table: "dbo.Workouts", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Workouts", name: "IX_ApplicationUserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Workouts", name: "ApplicationUserID", newName: "ApplicationUser_Id");
        }
    }
}
