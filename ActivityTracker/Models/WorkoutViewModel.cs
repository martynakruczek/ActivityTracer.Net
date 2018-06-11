using ActivityTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ActivityTracker.Models
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public eSport ? Sport { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of workout")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime ? DateOfWorkout { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Start")]
        public DateTime? StartAt { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "End")]
        public DateTime? EndAt { get; set; }
        public string ApplicationUserID { get; set; }

    }
}