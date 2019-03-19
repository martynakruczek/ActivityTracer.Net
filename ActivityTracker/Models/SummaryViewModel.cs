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
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        //public Dictionary<double?, int?> GetDataToChart(DateTime date)
        //{
        //    var ctx = new ApplicationDbContext();
        //    var steps = ctx.Steps.Where(x => DbFunctions.TruncateTime(x.Day) == date.Date);
        //    var stepsValue = steps.Select(x => x.NumberOfSteps).ToList();
        //    Dictionary<double?, int?> valuePairs = new Dictionary<double?, int?>();
        //    List<int?> stepValue = new List<int?>();
        //    stepValue.AddRange(stepsValue);
        //    List<ColumnSeriesData> vData = new List<ColumnSeriesData>();
        //    var timeValues = steps.Select(x => x.Day.Value).ToList();
        //    List<double?> timeValue = new List<double?>();
        //    foreach (var item in timeValues)
        //    {
        //        timeValue.Add(new TimeSpan(item.Ticks).TotalMilliseconds);
        //    }
        //    for (int i = 0; i < timeValue.Count(); i++)
        //    {
        //        valuePairs.Add(timeValue[i], stepValue[i]);
        //    }
        //    foreach (var item in valuePairs)
        //    {
        //        vData.Add(new ColumnSeriesData { X = item.Key, Y = item.Value });
        //    }
        //    return valuePairs;
        //}
    }
}