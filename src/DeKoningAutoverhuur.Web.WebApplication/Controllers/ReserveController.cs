using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using DeKoningAutoverhuur.Web.WebApplication.Common.Objects;
using DeKoningAutoverhuur.Web.WebApplication.Models.ReserveViewModels;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            HttpContext.Session.SetString("fromdatetime", model.fromdatetime);
            HttpContext.Session.SetString("todatetime", model.todatetime);
            HttpContext.Response.Redirect("/reserve/cars");
            return View("~/Views/Shared/_Redirect.cshtml");
        }

        // GET: /<controller>/
        public IActionResult Cars()
        {
            List<CarModelObject> carmodels = new List<CarModelObject>();
            CarModelObject carmodel = new CarModelObject();
            carmodel.Id = "1";
            carmodel.Brand = "Audi";
            carmodel.Model = "A6";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "audi-a6.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "2";
            carmodel.Brand = "Fiat";
            carmodel.Model = "Punto";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "fiat-punto.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "3";
            carmodel.Brand = "Mercedes";
            carmodel.Model = "Sprinter";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "mercedes-sprinter.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "4";
            carmodel.Brand = "Renault";
            carmodel.Model = "Clio";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "renault-clio.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "5";
            carmodel.Brand = "Tesla";
            carmodel.Model = "Model S";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "tesla-s.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "6";
            carmodel.Brand = "Volvo";
            carmodel.Model = "V90";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "volvo-v90.jpg";
            carmodels.Add(carmodel);

            ViewData["carmodels"] = carmodels;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cars(CarsViewModel model)
        {
            List<CarModelObject> carmodels = new List<CarModelObject>();
            CarModelObject carmodel = new CarModelObject();
            carmodel.Id = "1";
            carmodel.Brand = "Audi";
            carmodel.Model = "A6";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "audi-a6.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "2";
            carmodel.Brand = "Fiat";
            carmodel.Model = "Punto";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "fiat-punto.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "3";
            carmodel.Brand = "Mercedes";
            carmodel.Model = "Sprinter";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "mercedes-sprinter.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "4";
            carmodel.Brand = "Renault";
            carmodel.Model = "Clio";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "renault-clio.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "5";
            carmodel.Brand = "Tesla";
            carmodel.Model = "Model S";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "tesla-s.jpg";
            carmodels.Add(carmodel);

            carmodel = new CarModelObject();
            carmodel.Id = "6";
            carmodel.Brand = "Volvo";
            carmodel.Model = "V90";
            carmodel.Transmission = "Manual";
            carmodel.Segment = "A";
            carmodel.Image = "volvo-v90.jpg";
            carmodels.Add(carmodel);

            ViewData["carmodels"] = carmodels;
            HttpContext.Session.SetString("carmodel", model.carmodel);
            HttpContext.Response.Redirect("/reserve/details");
            return View("~/Views/Shared/_Redirect.cshtml");
        }

        // GET: /<controller>/
        public IActionResult Details()
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(DetailsViewModel model)
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

            string messageText = @"Er is een nieuwe reservering voor " + model.fromdatetime + @".
Gegevens Klant
Naam = " + model.name_firstname + @" " + model.name_prefix + @" " + model.name_lastname + @"
Adres = " + model.address_street + @" " + model.address_number + @" " + model.address_suffix + @"
postcode = " + model.address_zipcode + @"
city = " + model.address_city + @"
country = " + model.address_country + @"
phone = " + model.phone_countrycode + @" " + model.phone_areacode + @" " + model.phone_subscribernumber + @"

Gewenste Auto
car = " + model.car + @"";

            var message = new MimeMessage();

            message.To.Add(new MailboxAddress("receptie", "receptie@koningverhuur.auto"));

            message.From.Add(new MailboxAddress("Website", "noreply@koningverhuur.auto"));
            message.Subject = "Nieuwe reservering";
            message.Body = new TextPart("plain")
            {
                Text = messageText
            };

            using (var client = new SmtpClient())
            {
                client.Connect("localhost", 25, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Send(message);
                client.Disconnect(true);
            }
            return View("~/Views/Reserve/IndexSuccess.cshtml");
        }

        // GET: /<controller>/
        public IActionResult Payment()
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
            return View();
        }

        // GET: /<controller>/
        public IActionResult PayPal()
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
            return View();
        }

        // GET: /<controller>/
        public IActionResult CreditCard()
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
            return View();
        }

        // GET: /<controller>/
        public IActionResult Success()
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
            return View();
        }

    }
}
