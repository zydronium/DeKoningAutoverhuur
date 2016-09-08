using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using DeKoningAutoverhuur.Web.WebApplication.Models.ReserveVielModels;
using DeKoningAutoverhuur.Web.WebApplication.Common.Objects;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DeKoningAutoverhuur.Web.WebApplication.Controllers
{
    public class ReserveController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List <CarObject> cars = new List<CarObject>();
            CarObject car = new CarObject();
            car.LicensePlate = "12-34-AB";
            car.Brand = "Mercedes";
            car.Model = "A";
            car.Transmission = "Manual";
            car.Segment = "A";
            cars.Add(car);

            ViewData["cars"] = cars;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ReserveViewModel model)
        {
            List<CarObject> cars = new List<CarObject>();
            CarObject car = new CarObject();
            car.LicensePlate = "12-34-AB";
            car.Brand = "Mercedes";
            car.Model = "A";
            car.Transmission = "Manual";
            car.Segment = "A";
            cars.Add(car);

            ViewData["cars"] = cars;

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
