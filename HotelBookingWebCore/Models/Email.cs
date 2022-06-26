using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Models
{
    public class EmailViewModal
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
    }

    public class ConfirmationEmailViewModal
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Time { get; set; }
        public string ReservedDate { get; set; }
        public string Room { get; set; }
        public int Total { get; set; }
    }
}
