using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using HotelBookingWebCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Controllers
{
    public class BookingController : Controller
    {
        BookingRepo repo = new BookingRepo();
        public IActionResult BookingList()
        {
            return View("booking-list");
        }

        // Adding Booking 
        public JsonResult AddBooking(Booking model)
        {
            string msg = repo.AddBooking(model);
            return Json(msg);   
        }

        // View All Bookings
        public JsonResult GetAllBookings()
        {
            var data = repo.GetAllBookings();
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
            return PartialView("_bookingListModal", model);
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
