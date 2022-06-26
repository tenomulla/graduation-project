using HotelBookingWebCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepo repo = new CustomerRepo();
        public IActionResult CustomerList()
        {
            return View("customer-list");
        }

        // Get All Customers
        public JsonResult GetAllCustomers()
        {
            return Json(repo.GetAllCustomers());
        }
    }
}
