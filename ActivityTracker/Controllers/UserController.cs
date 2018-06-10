using ActivityTracker.BLL;
using ActivityTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityTracker.Controllers
{
    public class UserController : Controller
    {
        private WorkoutManager _workoutManager;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _workoutManager = new WorkoutManager();

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
        public ActionResult AddWorkout(WorkoutViewModel workoutvm)
        {
            var workout = new Workout()
            {
                Id = workoutvm.Id,
                Title = workoutvm.Title,
                DateOfWorkout = workoutvm.DateOfWorkout,
                Duration = workoutvm.Duration,
                Sport = workoutvm.Sport
            };
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user.ListOfWorkouts == null)
            {
                user.ListOfWorkouts = new List<Workout>();
            }
            user.ListOfWorkouts.Add(workout);
            _workoutManager.Add(workout);
            var result = UserManager.UpdateAsync(user);
            SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Summary()
        {
            return View(_workoutManager.GetWorkouts().Select(x => new WorkoutViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Sport = x.Sport,
                Duration = x.Duration,
                DateOfWorkout = x.DateOfWorkout,
            }));
        }
        [Authorize]
        public ActionResult Goal()
        {
            return View();
        }

    }
}