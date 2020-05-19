using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_HangFire3.Controllers
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
            BackgroundJob.Enqueue(() => Send("Tony Hello!"));
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void Send(string message)
        {
            Debug.WriteLine($"由Hangfire發送的訊息:{message}, 時間:{DateTime.Now}");
        }
    }
}