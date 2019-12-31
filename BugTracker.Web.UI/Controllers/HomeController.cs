using BugTracker.Data.Interfaces;
using BugTracker.Data.Repositories;
using BugTracker.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private IBugRepository _BugRepository;
        private ITicket _Ticket;

        public HomeController()
        {

        }

        public HomeController(IBugRepository bugRepository, ITicket ticket)
        {
            _Ticket = ticket;
            _BugRepository = bugRepository;
        }

        public ActionResult Index()
        {
            var model = _BugRepository.GetAll();

            var ticket = _Ticket.Get(Guid.Parse("806BE503-677E-4B08-954B-4FC78395FC19"));

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