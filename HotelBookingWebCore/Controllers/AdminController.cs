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
    public class AdminController : Controller
    {
        AdminRepo repo = new AdminRepo();

        // AdminList Page Display
        public IActionResult AdminList()
        {
            return View("admin-list");
        }

        // Get All Admins
        public JsonResult GetAllAdmins()
        {
            return Json(repo.GetAllUsers());
        }

        public JsonResult AddNewUser(User model)
        {
            return Json(repo.AddNewUser(model));
        }

        // Getting User By Id
        public JsonResult FetchUserById(int Id)
        {
            var data = repo.GetUserById(Id);
            return Json(data);
        }

        // Update User
        public JsonResult UpdateUserById(User model)
        {
            var msg = repo.UpdateUserById(model);
            return Json(msg);
        }

        // Delete Admin 
        public JsonResult DeleteAdminById(int UserId)
        {
            return Json(repo.DeleteAdminById(UserId));
        }
    }
}
