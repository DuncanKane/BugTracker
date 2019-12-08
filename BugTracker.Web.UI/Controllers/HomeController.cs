using BugTracker.Data.Interfaces;
using BugTracker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private IBugRepository _db;
        public HomeController(IBugRepository db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}