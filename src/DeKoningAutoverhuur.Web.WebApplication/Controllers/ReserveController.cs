using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using DeKoningAutoverhuur.Web.WebApplication.Models.ReserveVielModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DeKoningAutoverhuur.Web.WebApplication.Controllers
{
    public class ReserveController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ReserveViewModel model)
        {
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress("receptie", "receptie@koningverhuur.auto"));

            message.From.Add(new MailboxAddress("Website", "noreply@koningverhuur.auto"));
            message.Subject = "Nieuwe reservering";
            message.Body = new TextPart("plain")
            {
                Text = "Er is een nieuwe reservering voor vandaag."
            };

            using (var client = new SmtpClient())
            {
                client.Connect("localhost", 25, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Send(message);
                client.Disconnect(true);
            }
            return View();
        }

    }
}
