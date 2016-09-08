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
            var test = HttpContext;

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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(DetailsViewModel model)
        {
            HttpContext.Session.SetString("name_initials", model.name_initials);
            HttpContext.Session.SetString("name_firstname", model.name_firstname);
            HttpContext.Session.SetString("name_prefix", model.name_prefix);
            HttpContext.Session.SetString("name_lastname", model.name_lastname);
            HttpContext.Session.SetString("phone_countrycode", model.phone_countrycode);
            HttpContext.Session.SetString("phone_areacode", model.phone_areacode);
            HttpContext.Session.SetString("phone_subscribernumber", model.phone_subscribernumber);
            HttpContext.Session.SetString("email", model.email);
            HttpContext.Session.SetString("address_country", model.address_country);
            HttpContext.Response.Redirect("/reserve/payment");
            return View("~/Views/Shared/_Redirect.cshtml");
        }

        // GET: /<controller>/
        public IActionResult Payment()
        {
            List<PaymentObject> payments = new List<PaymentObject>();
            PaymentObject payment = new PaymentObject();
            payment.Name = "Contant";
            payment.Identifier = "contant";
            payments.Add(payment);

            payment = new PaymentObject();
            payment.Name = "PayPal";
            payment.Identifier = "paypal";
            payments.Add(payment);

            payment = new PaymentObject();
            payment.Name = "Credit Card";
            payment.Identifier = "creditcard";
            payments.Add(payment);

            ViewData["payments"] = payments;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentViewModel model)
        {
            List<PaymentObject> payments = new List<PaymentObject>();
            PaymentObject payment = new PaymentObject();
            payment.Name = "Contant";
            payment.Identifier = "contant";
            payments.Add(payment);

            payment = new PaymentObject();
            payment.Name = "PayPal";
            payment.Identifier = "paypal";
            payments.Add(payment);

            payment = new PaymentObject();
            payment.Name = "Credit Card";
            payment.Identifier = "creditcard";
            payments.Add(payment);

            ViewData["payments"] = payments;
            HttpContext.Session.SetString("payment_provider", model.provider);

            if(model.provider == "contant")
            {
                HttpContext.Response.Redirect("/reserve/success");
            }
            else if (model.provider == "paypal")
            {
                HttpContext.Response.Redirect("/reserve/paypal");
            }
            else if (model.provider == "creditcard")
            {
                HttpContext.Response.Redirect("/reserve/creditcard");
            }

            return View("~/Views/Shared/_Redirect.cshtml");
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
