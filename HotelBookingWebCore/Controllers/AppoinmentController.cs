using HotelBookingWebCore.Models;
using HotelBookingWebCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Controllers
{
    public class AppoinmentController : Controller
    {
        AppoinmentRepo repo = new AppoinmentRepo();
        public IActionResult AppoinmentList()
        {
            return View("appoinment-list");
        }

        // View All Appoinment List
        public JsonResult GetAllAppoinment()
        {
            var data = repo.GetAllAppoinment();
            return Json(data);
        }

        // Fetch Appoinment By ID
        public JsonResult FetchAppoinmentById(int Id)
        {
            var data = repo.GetAppoinmentById(Id);
            return Json(data);
        }

        // Add New Appoinment
        public JsonResult AddNewAppoinment(string Time)
        {
            string msg = repo.AddNewAppoinment(Time);
            return Json(msg);
        }

        // Update Appoiment
        public JsonResult UpdateAppoinment(AppoinmentViewModel model)
        {
            string msg = repo.UpdateAppoinment(model);
            return Json(msg);
        }
    }
}
