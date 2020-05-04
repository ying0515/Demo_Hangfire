using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_HangFire.Models;

namespace Demo_HangFire.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire! About!"));
            BackgroundJob.Enqueue(() => new EmailSenderMissions().SendEmail(11, "Tony"));
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            BackgroundJob.Schedule(
                () => Console.WriteLine("Hello, world, Contact!"),
                TimeSpan.FromSeconds(5));
            return View();
        }
    }
}