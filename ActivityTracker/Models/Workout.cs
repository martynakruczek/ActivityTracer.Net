using ActivityTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ActivityTracker.Models
{
    public class Workout 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public eSport ? Sport { get; set; }
        public DateTime ? DateOfWorkout { get; set; }
        public DateTime ? StartAt { get; set; }
        public DateTime ? EndAt { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}