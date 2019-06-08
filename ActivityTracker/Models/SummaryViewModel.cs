using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ActivityTracker.Models
{
    public class SummaryViewModel
    {
        public WorkoutViewModel Workout { get; set; }
        public StepsViewModel Steps { get; set; }
        public DateTime Date { get; set; }
    }
}