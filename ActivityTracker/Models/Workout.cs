using ActivityTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTracker.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public eSport ? Sport { get; set; }
        public DateTime DateOfWorkout { get; set; }
        public DateTime Duration { get; set; }
    }
}