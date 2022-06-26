using BookingWebsiteCore.Data;
using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Repositories
{
    public class CustomerRepo
    {
        BookingWebsite_DbContext db = new BookingWebsite_DbContext();

        // Get All Customers
        public IList<Customer> GetAllCustomers()
        {
            var data = db.Customers.ToList();
            return data;
        }
    }
}
