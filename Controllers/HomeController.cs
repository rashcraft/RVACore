using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        includeData incData = new includeData();
        public IActionResult Index()
        {
            ViewBag.Date = incData.dateTimeReturn();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
