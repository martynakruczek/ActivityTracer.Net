using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTracker.Models
{
    public class Steps
    {
        public int Id { get; set; }
        public int NumberOfSteps { get; set; }
        public DateTime DailyCount { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}