namespace ActivityTracker.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ActivityTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ActivityTracker.Models.ApplicationDbContext";
        }

        protected override void Seed(ActivityTracker.Models.ApplicationDbContext context)
        {
        }
    }
}
