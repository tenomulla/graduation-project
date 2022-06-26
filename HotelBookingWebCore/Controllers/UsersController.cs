using HotelBookingWebCore.Models;
using HotelBookingWebCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Controllers
{
    public class UsersController : Controller
    {
        UserRepo repo = new UserRepo();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View("signin");
        }

        public IActionResult Frame1()
        {
            return View();
        }

        //public IActionResult Frame2()
        //{
        //    return View();
        //}

        public IActionResult Frame3(int BookingId)
        {
            string pagename = "Frame1";
            BookingDetailViewModel model = new BookingDetailViewModel();
            if (!string.IsNullOrEmpty(BookingId.ToString()) && BookingId != 0)
            {
                model = repo.GetBookingsDatabyId(BookingId);
                if (model.CouponId == 0)
                {
                    pagename = "Frame3";
                }
                else
                {
                    pagename = "Frame5";
                }
            }
            return View(pagename, model);
        }
        public IActionResult Frame4(int BookingId)
        {
            string pagename = "Frame1";
            BookingDetailViewModel model = new BookingDetailViewModel();
            if (!string.IsNullOrEmpty(BookingId.ToString()) && BookingId != 0)
            {
                pagename = "Frame4";
                model = repo.GetBookingsDatabyId(BookingId);
            }
            return View(pagename, model);
        }

        public IActionResult Frame5(int BookingId)
        {
            string pagename = "Frame1";
            BookingDetailViewModel model = new BookingDetailViewModel();
            if (!string.IsNullOrEmpty(BookingId.ToString()) && BookingId != 0)
            {
                model = repo.GetBookingsDatabyId(BookingId);
                if(model.CouponId != 0)
                {
                    pagename = "Frame5";
                }
                else
                {
                    pagename = "Frame3";
                }
            }
            return View(pagename, model);
        }

        public IActionResult Frame6()
        {
            return View();
        }

        public IActionResult Frame7()
        {
            return View();
        }

        // Login Method Begins here
        public JsonResult Getlogin(string UserName, string Pass)
        {
            string Msg = "Failed";
            UsersViewModel uModel = new UsersViewModel();
            try
            {
                if (UserSession.USession == null)
                {
                    UsersViewModel data = repo.GetLoginInfo(UserName, Pass);
                    if (data != null)
                    {
                        if(data.Id != 0)
                        {
                            //Here is setting session
                            Msg = "Success";
                            HttpContext.Session.SetString("FullName", data.FullName);
                            HttpContext.Session.SetString("UserType", data.UserType);
                            HttpContext.Session.SetInt32("UserSessionId", data.Id);
                            HttpContext.Session.SetString("UserName", data.UserName);
                            HttpContext.Session.SetString("Password", data.Password);
                            uModel.FullName = HttpContext.Session.GetString("FullName");
                            uModel.UserName = HttpContext.Session.GetString("UserName");
                            uModel.UserType = HttpContext.Session.GetString("UserType");
                            uModel.Id = Convert.ToInt32(HttpContext.Session.GetInt32("UserSessionId"));
                            uModel.Password = HttpContext.Session.GetString("Password");
                            UserSession.USession = uModel;
                            Redirect("/Home/Index");
                        }
                        else
                        {
                            Msg = "Failed";
                        }
                    }
                    else
                    {
                        UserSession.USession = null;
                    }
                }
                else
                {
                    Msg = "Success";
                    Redirect("/Home/Index");
                }
            }
            catch(Exception ex)
            {

            }
            return Json(Msg);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            UserSession.USession = null;
            return Redirect("/Users/SignIn");
        }

        // Getting Appoinment Times
        public JsonResult GetAppoinmentTimes(DateTime AppoinmentDate)
        {
            var data = repo.GettingAppoinmentTimes(AppoinmentDate).OrderBy(x=>x.Time).ToList();
            return Json(data);
        }

        // Book Now
        public JsonResult BookNow(BookNowViewModel model)
        {
            string Msg = "Failed";
            int Id = repo.BookNow(model);
            if (Id != 0)
            {
                Msg = "Added";
            }
            return Json(new { Msg = Msg, Id = Id});
        }

        // Redirecting to the Frame2
        public IActionResult Frame2(int bookingId)
        {
            string pagname = "Frame1";
            BookingDetailViewModel model = new BookingDetailViewModel();
            if (!string.IsNullOrEmpty(bookingId.ToString()) && bookingId != 0)
            {
                model = repo.GetBookingsDatabyId(bookingId);
                if (string.IsNullOrEmpty(model.CouponName))
                {
                    DateTime laterDate = DateTime.Now.AddDays(2).Date;
                    if (model.BookedDate.Value.Date >= laterDate)
                    {
                        pagname = "Frame3";
                    }
                    else
                    {
                        pagname = "Frame2";
                    }
                }
                else
                {
                    model.Total = Convert.ToInt32(model.Amount) * Convert.ToInt32(model.Size);
                    DateTime laterDate = DateTime.Now.AddDays(2).Date;
                    if (model.BookedDate.Value.Date >= laterDate)
                    {
                        pagname = "Frame5";
                    }
                    else
                    {
                        pagname = "Frame4";
                    }
                }
            }
            return View(pagname, model);
        }

        // Apply Coupon
        public JsonResult ApplyCoupon(string CouponCode, int bookingId)
        {
            string msg = "Failed";
            int Total = repo.ApplyCoupon(CouponCode, bookingId);
            if(Total > 0)
            {
                msg = "Applied";
            }
            return Json(new { msg = msg , Total = Total});
        }

        // Load Rooms Info
        public JsonResult LoadRoomsInfo()
        {
            return Json(repo.GetAllRooms());
        }

        // Send Query
        public JsonResult SendQuery(EmailViewModal model)
        {
            return Json(repo.SendQuery(model));
        }

        // Deleting Coupon 
        public JsonResult DeleteCoupon(int bookingId)
        {
            return Json(repo.DeleteCoupon(bookingId));
        }

        public JsonResult GetAllRooms()
        {
            return Json(repo.GetAllRooms());
        }
    }
}
