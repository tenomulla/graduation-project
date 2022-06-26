﻿using BookingWebsiteCore.Data;
using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Repositories
{
    public class HomeRepo
    {
        BookingWebsite_DbContext db = new BookingWebsite_DbContext();
        
        // Getting Todays Booking
        public async Task<IList<Booking>> GetTodaysBooking()
        {
            //var afterDate = Convert.ToDateTime(DateTime.Now).ToShortDateString();
            var beforeDate = Convert.ToDateTime(DateTime.Now).ToShortDateString();
            var data = await Task.Run(() => db.Bookings.AsEnumerable().Where(x => Convert.ToDateTime(x.BookedDate).ToShortDateString() == beforeDate).ToList());
            return data;
        }

        // Getting Tomorrows Booking
        public async Task<IList<Booking>> GetTomorrowsBooking()
        {
            var data = new List<Booking>();
            try
            {
                var CurrDate = Convert.ToDateTime(DateTime.Now.AddDays(1)).ToShortDateString();
                data = await Task.Run(() => db.Bookings.AsEnumerable().Where(x => Convert.ToDateTime(x.BookedDate).ToShortDateString() == CurrDate).ToList());
            }
            catch(Exception ex)
            {

            }
            return data;
        }

        public BookingDetailViewModel GetBookingsById(int id)
        {
            var Bookingdata = db.Bookings.Where(x => x.Id == id).FirstOrDefault();
            var couponData = db.CoupnLists.Where(x => x.Id == Bookingdata.CouponId).FirstOrDefault();
            IList<HistoryLog> history = db.HistoryLogs.Where(x => x.BookingId == Bookingdata.Id).ToList();
            BookingDetailViewModel details = new BookingDetailViewModel();
            details.Id = Bookingdata.Id;
            details.BookedDate = Bookingdata.BookedDate;
            details.Category = Bookingdata.Category;
            details.Comment = Bookingdata.Comment;
            details.Name = Bookingdata.GuestName;
            details.Time = Bookingdata.Time;
            if (couponData != null)
            {
                details.CouponName = couponData.Name;
                details.DiscountPercent = couponData.DiscountPercent.ToString();
            }
            details.PaymentCode = Bookingdata.PaymentCode;
            details.PhonNo = Bookingdata.PhoneNo;
            details.Room = Bookingdata.Room;
            details.Size = Bookingdata.Size.ToString();
            details.Status = Bookingdata.Status;
            details.History = history;
            details.EnteredDate = Bookingdata.EnteredDate;
            details.Amount = Convert.ToInt32(Bookingdata.Amount);
            details.Total = Convert.ToInt32(Bookingdata.Total);
            return details;
        }

        // Update Booking
        public string UpdateBooking(Booking model)
        {
            string msg = "Failed";
            var data = db.Bookings.Where(x => x.Id == model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Category = model.Category;
                //data.Amount = Convert.ToDecimal(model.Amount == null ? 0 : model.Amount);
                data.PhoneNo = model.PhoneNo;
                data.Comment = model.Comment;
                //data.Date = model.Date;
                data.GuestName = model.GuestName;
                //data.Room = model.Room;
                data.Size = model.Size;
                data.Status = model.Status;
                db.SaveChanges();
                msg = "Updated";

                if(model.Status == "Canceled")
                {
                    var apList = db.AppoinmentRoomLists.Where(x => x.Room == model.Room).FirstOrDefault();
                    apList.Status = "Available";
                    db.SaveChanges();
                }

                var history = db.HistoryLogs.Where(x => x.BookingId == model.Id).FirstOrDefault();
                if (history != null)
                {
                    if (!history.Description.Contains("Comment") && !history.Description.Contains("Status"))
                    {
                        HistoryLog lg = new HistoryLog();
                        lg.AddedBy = UserSession.USession.Id;
                        lg.Date = DateTime.Now;
                        lg.BookingId = model.Id;
                        lg.AddedByName = UserSession.USession.FullName;
                        lg.Description = "Changed the comment";
                        db.HistoryLogs.Add(lg);
                        db.SaveChanges();
                    }
                    else if (!history.Description.Contains("Comment") && !history.Description.Contains("Status"))
                    {
                        HistoryLog lg = new HistoryLog();
                        lg.AddedBy = UserSession.USession.Id;
                        lg.Date = DateTime.Now;
                        lg.BookingId = model.Id;
                        lg.AddedByName = UserSession.USession.UserName;
                        lg.AddedByName = UserSession.USession.FullName;
                        lg.Description = "Added a comment";
                        db.HistoryLogs.Add(lg);
                        db.SaveChanges();
                    }
                    else if (history.Description.Contains("Status"))
                    {
                        HistoryLog lg = new HistoryLog();
                        lg.AddedBy = UserSession.USession.Id;
                        lg.Date = DateTime.Now;
                        lg.BookingId = model.Id;
                        lg.AddedByName = UserSession.USession.FullName;
                        lg.Description = "Changed The Status to " + model.Status;
                        db.HistoryLogs.Add(lg);
                        db.SaveChanges();
                    }
                    else
                    {
                        HistoryLog lg = new HistoryLog();
                        lg.AddedBy = UserSession.USession.Id;
                        lg.Date = DateTime.Now;
                        lg.BookingId = model.Id;
                        lg.AddedByName = UserSession.USession.FullName;
                        lg.Description = "Changed The Status to " + model.Status;
                        db.HistoryLogs.Add(lg);
                        db.SaveChanges();
                    }
                }
                else
                {
                    HistoryLog lg = new HistoryLog();
                    lg.AddedBy = UserSession.USession.Id;
                    lg.Date = DateTime.Now;
                    lg.BookingId = model.Id;
                    lg.AddedByName = UserSession.USession.FullName;
                    lg.Description = "Added a Comment";
                    db.HistoryLogs.Add(lg);
                    db.SaveChanges();
                }
            }
            return msg;
        }

        // Deleteing Booking
        public string DeleteBookingList(int BookedId)
        {
            string msg = "Failed";
            var data = db.Bookings.Find(BookedId);
            if (data != null)
            {
                db.Bookings.Remove(data);
                db.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        // Deleteing Booking and make it available
        public string DeleteBookingAndMakeitAvailable(int BookedId)
        {
            string msg = "Failed";
            var data = db.Bookings.Find(BookedId);
            if (data != null)
            {
                var apList = db.AppoinmentRoomLists.Where(x => x.Room == data.Room).FirstOrDefault();
                apList.Status = "Available";
                db.SaveChanges();
                db.Bookings.Remove(data);
                db.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        // Update Status
        public string UpdateStatus(int BookingId, string Status)
        {
            string msg = "Updated";
            var BookingData = db.Bookings.Where(x => x.Id == BookingId).FirstOrDefault();
            if(Status == "Canceled")
            {
                var ap = db.AppoinmentLists.Where(x => x.Time == BookingData.Time).FirstOrDefault();
                var apList = db.AppoinmentRoomLists.Where(x => x.Room == BookingData.Room && x.AppoinmentId == ap.Id).FirstOrDefault();
                apList.Status = "Available";
                db.SaveChanges();
            }
            else
            {
                var ap = db.AppoinmentLists.Where(x => x.Time == BookingData.Time).FirstOrDefault();
                var apList = db.AppoinmentRoomLists.Where(x => x.Room == BookingData.Room && x.AppoinmentId == ap.Id).FirstOrDefault();
                apList.Status = "Hidden";
                db.SaveChanges();
            }
            BookingData.Status = Status;
            db.SaveChanges();
            return msg;
        }
    }
}
