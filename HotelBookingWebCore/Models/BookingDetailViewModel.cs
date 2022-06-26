using BookingWebsiteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Models
{
    public class BookingDetailViewModel
    {
        public int Id { get; set; }
        public string Room { get; set; }
        public DateTime? BookedDate { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string PhonNo { get; set; }
        public string Category { get; set; }
        public string PaymentCode { get; set; }
        public string CouponName { get; set; }
        public int CouponId { get; set; }
        public string DiscountPercent { get; set; }
        public string Comment { get; set; }
        public string Time { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
        public IList<HistoryLog> History { get; set; }

        public string HistoryinTxt { get; set; }

    }
    
    public class BookNowViewModel
    {
        public int AppoinmentId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int Size { get; set; }
        public string Category { get; set; }
        public DateTime BookDate { get; set;}
        public string Time { get; set; }
    }
}
