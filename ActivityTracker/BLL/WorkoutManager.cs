using ActivityTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTracker.BLL
{
    public class WorkoutManager
    {
        private readonly ApplicationWorkoutDbContext _context;

        public WorkoutManager()
        {
            _context = new ApplicationWorkoutDbContext();
        }

        public IEnumerable<Workout> GetWorkouts()
        {
            return _context.Workouts;
        }

        public void Add(Workout w)
        {
            _context.Workouts.Add(w);
            _context.SaveChanges();
        }
    }
}