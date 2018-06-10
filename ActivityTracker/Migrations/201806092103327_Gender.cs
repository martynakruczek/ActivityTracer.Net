namespace ActivityTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Sex", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Gender");
        }
    }
}
