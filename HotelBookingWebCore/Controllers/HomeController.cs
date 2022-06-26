using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using HotelBookingWebCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HomeRepo repo = new HomeRepo();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Policies()
        {
            return View("policies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Getting Todays Booking
        public JsonResult GetTodaysBooking()
        {
            var data = repo.GetTodaysBooking().Result;
            return Json(data);
        }

        // Getting Tomorrows Booking
        public JsonResult GetTomorrowsBooking()
        {
            var data = repo.GetTomorrowsBooking().Result;
            return Json(data);
        }

        public IActionResult GetBookingById(int BookingId)
        {
            var model = repo.GetBookingsById(BookingId);
            string txtArea = "";
            foreach (var value in model.History)
            {
                txtArea += String.Format("{0} | {1} {2} \n {3} \n \n", value.AddedByName, value.Date.Value.ToString("dd/MM/yyyy"), value.Date.Value.ToString("hh:mm tt"), value.Description);
            }
            model.HistoryinTxt = txtArea;
            return PartialView("_bookingModal", model);
        }

        public JsonResult UpdateBooking(Booking model)
        {
            return Json(repo.UpdateBooking(model));
        }

        // Deleteing Booking
        public JsonResult DeleteBookingList(int BookedId)
        {
            return Json(repo.DeleteBookingList(BookedId));
        }

        // Delete Booking and make it available
        public JsonResult DeleteBookingAndMakeitAvailable(int BookedId)
        {
            return Json(repo.DeleteBookingAndMakeitAvailable(BookedId));
        }

        // Update Sttaus
        public JsonResult UpdateStatus(int BookingId, string Status)
        {
            return Json(repo.UpdateStatus(BookingId, Status));
        }
    }
}
