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
    public class CouponController : Controller
    {
        CouponRepo repo = new CouponRepo();
        public IActionResult CouponList()
        {
            return View("coupon-list");
        }

        public JsonResult AddCoupon(CoupnList model)
        {
            string msg = repo.AddCoupon(model);
            return Json(msg);
        }

        public JsonResult GetCoupons()
        {
            var data = repo.GetAllCoupons();
            return Json(data);
        }

        // Update Coupon
        public JsonResult UpdateCoupon(CoupnList model)
        {
            string msg = repo.UpdateCoupon(model);
            return Json(msg);
        }

        // Get Coupon By Id
        public JsonResult GetCouponById(int Id)
        {
            var data = repo.GetCouponById(Id);
            return Json(data);
        }

        public JsonResult DeleteCoupon(int Id)
        {
            return Json(repo.DeleteCoupon(Id));
        }
    }
}
