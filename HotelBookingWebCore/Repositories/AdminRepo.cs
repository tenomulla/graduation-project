using BookingWebsiteCore.Data;
using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Repositories
{
    public class AdminRepo
    {
        BookingWebsite_DbContext db = new BookingWebsite_DbContext();
        public IList<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public string AddNewUser(User model)
        {
            string msg = "Added";
            var exist = db.Users.Where(x => x.UserName == model.UserName).FirstOrDefault();
            if(exist == null)
            {
                var data = db.Users.Add(model);
                db.SaveChanges();
                if (data == null)
                {
                    msg = "Failed";
                }
            }
            else
            {
                msg = "Already";
            }
            return msg;
        }

        // Get User By Id
        public User GetUserById(int Id)
        {
            return db.Users.Where(x => x.Id == Id).FirstOrDefault();
        }

        // Delete Admin By Id
        public string DeleteAdminById(int UserId)
        {
            string msg = "Failed";
            var user = db.Users.Where(x => x.Id == UserId).FirstOrDefault();
            if(user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        public string UpdateUserById(User model)
        {
            string msg = "Failed";
            var data = db.Users.Where(x => x.Id == model.Id).FirstOrDefault();
            if(data != null)
            {
                data.FullName = model.FullName;
                data.Password = model.Password;
                data.UserName = model.UserName;
                data.UserType = model.UserType;
                db.SaveChanges();
                msg = "Updated";
            }
            return msg;
        }
    }
}
