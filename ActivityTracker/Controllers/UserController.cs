using ActivityTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityTracker.Controllers
{
    public class UserController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;

        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [Authorize]
        public ActionResult Index()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var vm = new UserViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                Gender = user.Gender,
                BirthDate = user.BirthDate
            };
            return View(vm);
        }

        [Authorize]
        public ActionResult AddWorkout()
        {
            return View(new WorkoutViewModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddWorkout(WorkoutViewModel vm)
        {
            var userId = User.Identity.GetUserId();

            var ctx = new ApplicationDbContext();
            IEnumerable<Workout> workouts = new List<Workout>();

            var workout = new Workout()
            {
                Title = vm.Title,
                DateOfWorkout = vm.DateOfWorkout,
                StartAt = vm.StartAt,
                EndAt = vm.EndAt,
                Sport = vm.Sport,
                ApplicationUserID = userId,
                
            };
            ctx.Workouts.Add(workout);
            ctx.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult History()
        {
            var ctx = new ApplicationDbContext();
            var userId = User.Identity.GetUserId();
            var workouts = ctx.Workouts.Where(x => x.ApplicationUserID == userId).ToList();
            var model = workouts.Select(x => new WorkoutViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Sport = x.Sport,
                StartAt = x.StartAt,
                EndAt = x.EndAt,
                DateOfWorkout = x.DateOfWorkout,
            });
            return View(model);
        }

        [Authorize]
        public ActionResult EditWorkout(int id)
        {
            var ctx = new ApplicationDbContext();
            Workout workout = ctx.Workouts.Where(x => x.Id == id).First();

            var vm = new WorkoutViewModel()
            {
                Id = id,
                Title = workout.Title,
                Sport = workout.Sport,
                StartAt = workout.StartAt,
                EndAt = workout.EndAt,
                DateOfWorkout = workout.DateOfWorkout,
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditWorkout(WorkoutViewModel vm)
        {
            var workout = new Workout()
            {
                Id = vm.Id,
                Title = vm.Title,
                Sport = vm.Sport,
                StartAt = vm.StartAt,
                EndAt = vm.EndAt,
                DateOfWorkout = vm.DateOfWorkout,
                ApplicationUserID = User.Identity.GetUserId()
            };
            var ctx = new ApplicationDbContext();
            ctx.Entry(ctx.Workouts.FirstOrDefault(x=>x.Id == workout.Id))
                .CurrentValues.SetValues(workout);
            ctx.SaveChanges();
            return RedirectToAction("History");

        }

        [Authorize]
        public ActionResult Goal()
        {
            return View();
        }

    }
}