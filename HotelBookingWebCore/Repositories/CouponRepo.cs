using BookingWebsiteCore.Data;
using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Repositories
{
    public class CouponRepo
    {
        BookingWebsite_DbContext db = new BookingWebsite_DbContext();

        // Add New Coupon
        public string AddCoupon(CoupnList model)
        {
            string msg = "Failed";
            var data = db.CoupnLists.Add(model);
            db.SaveChanges();
            if(data != null)
            {
                msg = "Added";
            }
            return msg;
        }

        // Update Coupon
        public string UpdateCoupon(CoupnList model)
        {
            string msg = "Failed";
            var data = db.CoupnLists.Where(x => x.Id == model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = model.Name;
                //data.RelaseDate = model.RelaseDate;
                //data.Status = model.Status;
                data.Duration = model.Duration;
                data.DiscountPercent = model.DiscountPercent;
                db.SaveChanges();
                msg = "Updated";
            }
            return msg;
        }

        public CoupnList GetCouponById(int Id)
        {
            var data = db.CoupnLists.Where(x => x.Id == Id).FirstOrDefault();
            return data;
        }

        // Getting All Coupon
        public IList<CoupnList> GetAllCoupons()
        {
            var data = db.CoupnLists.ToList();
            return data;
        }

        public string DeleteCoupon(int Id)
        {
            var data = db.CoupnLists.Where(x => x.Id == Id).FirstOrDefault();
            db.Remove(data);
            db.SaveChanges();
            string msg = "Failed";
            return msg;
        }
    }
}
