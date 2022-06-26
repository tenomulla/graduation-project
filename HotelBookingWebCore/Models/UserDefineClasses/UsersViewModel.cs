using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string UserType { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}
