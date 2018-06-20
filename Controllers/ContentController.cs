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
    public class ContentController : Controller
    {
        public IActionResult Jager()
        {
            ViewBag.Message = "A page for das Jäger";
            return View();
        }

    }
}
