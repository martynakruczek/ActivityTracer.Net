using ActivityTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
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
            var user = UserManager.FindById(userId);
            var ctx = new ApplicationDbContext();
            if (user.ListOfWorkouts == null)
            {
                IEnumerable<Workout> workouts = new List<Workout>();
            }

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

            return RedirectToAction("History");
        }
       
        [Authorize]
        public ActionResult History()
        {
            var ctx = new ApplicationDbContext();

            var userId = User.Identity.GetUserId();
            var workouts = ctx.Workouts.Where(x => x.ApplicationUserID == userId).OrderByDescending(x => x.DateOfWorkout).ToList();
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
            ctx.Entry(ctx.Workouts.FirstOrDefault(x => x.Id == workout.Id))
                .CurrentValues.SetValues(workout);
            ctx.SaveChanges();
            return RedirectToAction("History");

        }

        public ActionResult DeleteWorkout(int id, bool? saveChangesError = false)
        {
            var ctx = new ApplicationDbContext();

            Workout workout = ctx.Workouts.Where(x => x.Id == id).FirstOrDefault();
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        [HttpPost]
        public ActionResult DeleteWorkout(int id)
        {
            var ctx = new ApplicationDbContext();
            Workout workout = ctx.Workouts.Where(x => x.Id == id).FirstOrDefault();
            ctx.Workouts.Remove(workout);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Summary()
        {
            var client = new System.Net.Http.HttpClient();
            var response = client.GetAsync("http://2d7fe7bc.ngrok.io/api/Steps").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var today = DateTime.Now;
            var date = new SummaryViewModel
            {
                Date = today,
            };

            List<Steps> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Steps>>(result);
            var steps = list.Where(x => x.Day.Date == date.Date.Date).ToList();
            ViewBag.Steps = steps.Select(x=>x.NumberOfSteps);
            ViewBag.Time = steps.Select(x => x.Day.ToShortTimeString());
            return View(date);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Summary(SummaryViewModel vm)
        {
            var userId = User.Identity.GetUserId();
            var date = new SummaryViewModel
            {
                Date = vm.Date
            };

            int[] steps = { 0, 100, 200, 300, 6000, 0, 500, 10000 };
            steps.ToArray();
            ViewBag.Steps = steps;
            return View(date);
        }

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                String userId = User.Identity.GetUserId();

                if (userId == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");

                }
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();
                if (userImage.UserAvatar == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
                    
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");
                }
                else
                {
                    return new FileContentResult(userImage.UserAvatar, "image/jpeg");
                }
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }
        }

    }
}