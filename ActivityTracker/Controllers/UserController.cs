using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityTracker.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Settings()
        {
            return View();
        }
        [Authorize]
        public ActionResult Trainings()
        {
            return View();
        }
        [Authorize]
        public ActionResult Summary()
        {
            return View();
        }
        [Authorize]
        public ActionResult Goal()
        {
            return View();
        }

    }
}