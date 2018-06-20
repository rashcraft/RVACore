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
    public class SupportController : Controller
    {
        // GET: Support/AffiliateNotifications
        public ActionResult AffiliateNotifications(string submit)
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel e)
        {
            if (ModelState.IsValid)
            {
                //prepare email
                var toAddress = "ashcraft.richard@gmail.com";
                var fromAddress = e.Email.ToString();
                var subject = "Website contact form send you a message from:  " + e.Name;
                var message = new StringBuilder();
                message.Append("Name: " + e.Name + "\n");
                message.Append("Email: " + e.Email + "\n");
                message.Append("Subject: " + e.Subject + "\n");
                //message.Append("Telephone: " + e.Telephone + "\n\n");
                message.Append(e.Message);

                MailMessage mailMessage = new MailMessage(toAddress, "ashcraft.richard@outlook.com", subject, message.ToString());
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(toAddress, "awqeocolycbwsxas"); //awqeocolycbwsxas
                try
                {
                    smtpClient.Send(mailMessage);
                    ViewBag.Message = "Thank you for your message.";
                }
                catch (Exception)
                {
                    ViewBag.Message = $"Sorry we are facing Problem here. The message was not sent.";
                    // dev version ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
