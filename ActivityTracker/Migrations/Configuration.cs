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
            SeedSteps(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
        private void SeedSteps(ActivityTracker.Models.ApplicationDbContext context)
        {
            IList<Models.Steps> defaultSteps = new List<Models.Steps> {
                new Models.Steps() { NumberOfSteps = 100, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,8,20,10)},
                new Models.Steps() { NumberOfSteps = 0, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,9,20,10)},
                new Models.Steps() { NumberOfSteps = 1000, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,10,20,10)},
                new Models.Steps() { NumberOfSteps = 2100, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,11,20,10)},
                new Models.Steps() { NumberOfSteps = 10, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,12,20,10)},
                new Models.Steps() { NumberOfSteps = 100, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,13,20,10)},
                new Models.Steps() { NumberOfSteps = 0, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,14,20,10)},
                new Models.Steps() { NumberOfSteps = 1000, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,15,20,10)},
                new Models.Steps() { NumberOfSteps = 200, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,16,20,10)},
                new Models.Steps() { NumberOfSteps = 100, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,17,20,10)},
                new Models.Steps() { NumberOfSteps = 500, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,18,20,10)},
                new Models.Steps() { NumberOfSteps = 0, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,19,20,10)},
                new Models.Steps() { NumberOfSteps = 100, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,20,20,10)},
                new Models.Steps() { NumberOfSteps = 1200, ApplicationUserID = "d2a1ce39-5e4d-4ff5-82b4-6928136e1e2b", Day = new DateTime(2018,6,13,21,20,10)},


            };

            context.Steps.AddRange(defaultSteps);
            context.SaveChanges();
        }
    }
}
