using BookingWebsiteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Models
{
    public class AppoinmentViewModel
    {
        public int Id { get; set; }
        public string[] RoomArr { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class AppoinmentListViewModel
    {
        public int Id { get; set; }
        public List<AppoinmentRoomList> RoomArr { get; set; }
        public string Time { get; set; }
    }

    public class AppoinmentGetViewModel
    {
        public int Id { get; set; }
        public string Rooms { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
