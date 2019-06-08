using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTracker.Models
{
    public class Steps
    {
        public int Id { get; set; }
        public int ? NumberOfSteps { get; set; }
        public DateTime Day { get; set; }
        public string ApplicationUserID { get; set; }
    }

    public class StepsDbContext : System.Data.Entity.DbContext
    {
        public StepsDbContext()
            : base("StepsDbContext")
        {
        }
        public System.Data.Entity.DbSet<Steps> StepsList { get; set; }
        public System.Data.Entity.DbSet<RawData> ListOfRawData { get; set; }

    }
}



