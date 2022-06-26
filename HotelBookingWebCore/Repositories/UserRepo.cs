using BookingWebsiteCore.Data;
using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Repositories
{
    public class UserRepo
    {
        BookingWebsite_DbContext db = new BookingWebsite_DbContext();
        public UsersViewModel GetLoginInfo(string UserName, string Pass)
        {
            var usr = new UsersViewModel();
            try
            {
                usr = db.Users.Where(x => x.UserName == UserName && x.Password == Pass).Select(x=> new UsersViewModel
                {
                    FullName = x.FullName,
                    UserName = x.UserName,
                    UserType = x.UserType,
                    Id = x.Id,
                    Password = x.Password,
                    ProfileImage = x.ProfileImage
                }).FirstOrDefault();
            }
            catch(Exception ex)
            {

            }
            return usr;
        }

        // Getting Appoinment Times
        public List<AppoinmentGetViewModel> GettingAppoinmentTimes(DateTime AppoinmentDate)
        {
            List<AppoinmentGetViewModel> list = new List<AppoinmentGetViewModel>();
            var appoinmentRoomList = db.AppoinmentRoomLists.Where(x => AppoinmentDate >= x.FromDate && AppoinmentDate <= x.ToDate).ToList();
            foreach(var value in appoinmentRoomList)
            {
                var ApList = db.AppoinmentLists.Where(x => x.Id == value.AppoinmentId).FirstOrDefault();
                list.Add(new AppoinmentGetViewModel
                {
                    Id = value.Id,
                    FromDate = value.FromDate,
                    Rooms = value.Room,
                    Status = value.Status,
                    Time = ApList.Time,
                    ToDate = value.ToDate
                });
            }

            return list;
        }

        // Book Now
        public int BookNow(BookNowViewModel model)
        {
            int EntityId = 0;
            string Msg = "Failed";
            if(model.Email != null || model.Name != null || model.PhoneNo != null)
            {
                var roomData = db.AppoinmentRoomLists.Where(x => x.Id == model.AppoinmentId).FirstOrDefault();
                string Time = db.AppoinmentLists.Where(x => x.Id == roomData.AppoinmentId).FirstOrDefault().Time;
                var RList = db.RoomLists.Where(x => x.Name == roomData.Room).FirstOrDefault();
                int? Amount = db.PriceLists.Where(x => x.NoOfRoom == model.Size && x.RoomId == RList.Id).FirstOrDefault().Price;
                Booking book = new Booking();
                book.BookedDate = model.BookDate;
                book.Time = Time;
                book.Status = "UnConfirmed";
                book.Size = model.Size;
                book.PhoneNo = model.PhoneNo;
                book.GuestName = model.Name;
                book.EnteredDate = DateTime.Now;
                book.Category = model.Category;
                book.Amount = Amount;
                book.Total = Amount == null ? 0 : Amount * model.Size;
                book.Room = roomData.Room;
                var data = db.Bookings.Add(book);
                db.SaveChanges();

                // Update Appointment Status
                roomData.Status = "Hidden";
                db.SaveChanges();

                Customer cust = new Customer();
                cust.Email = model.Email;
                cust.Name = model.Name;
                cust.Phone = model.PhoneNo;
                cust.Id = 0;
                db.Customers.Add(cust);
                db.SaveChanges();
                EntityId = data.Entity.Id;
                if (data != null)
                {
                    Msg = "Added";
                    ConfirmationEmailViewModal email = new ConfirmationEmailViewModal();
                    email.Email = model.Email;
                    email.Name = model.Name;
                    email.Phone = model.PhoneNo;
                    email.Total = Convert.ToInt32(book.Total);
                    email.Time = book.Time;
                    email.ReservedDate = model.BookDate.ToShortDateString();
                    email.Room = book.Room;
                    string emailRes = SendConfirmationEmail(email);
                }
            }
            return EntityId;
        }

        // Getting Bookings agains BookingId
        public BookingDetailViewModel GetBookingsDatabyId(int BookingId)
        {
            var data = db.Bookings.Where(x => x.Id == BookingId).Select(x => new BookingDetailViewModel
            {
                EnteredDate = x.EnteredDate,
                Id = x.Id,
                Name = x.GuestName,
                PhonNo = x.PhoneNo,
                BookedDate = x.BookedDate,
                Amount = Convert.ToInt32(x.Amount),
                Total = Convert.ToInt32(x.Total),
                Category = x.Category,
                Room = x.Room,
                Size = x.Size.ToString(),
                Status = x.Status,
                CouponId = Convert.ToInt32(x.CouponId),
                Time = x.Time
            }).FirstOrDefault();
            var couponData = db.CoupnLists.Where(x => x.Id == data.CouponId).FirstOrDefault();
            if(couponData != null)
            {
                data.CouponName = couponData.Name;
                data.DiscountPercent = couponData.DiscountPercent.ToString();
            }
            return data;
        }

        // Apply Coupon 
        public int ApplyCoupon(string Code, int BookingId)
        {
            int Total = 0;
            var coupon = db.CoupnLists.Where(x => x.Name == Code).FirstOrDefault();
            var CurrDate = Convert.ToDateTime(DateTime.Now).ToShortDateString();
            if (coupon != null)
            {
                if(DateTime.Now <= DateTime.Now.AddDays(Convert.ToDouble(coupon.Duration)))
                {
                    var booking = db.Bookings.Where(x => x.Id == BookingId).FirstOrDefault();
                    int discountAmt = Convert.ToInt32(booking.Total) * Convert.ToInt32(coupon.DiscountPercent) / 100;
                    booking.Total = booking.Total - discountAmt;
                    booking.CouponId = coupon.Id;
                    Total = Convert.ToInt32(booking.Total);
                    db.SaveChanges();
                }
                else
                {
                    Total = 0;
                }
            }
            return Total;
        }

        // Deleting Coupon
        public string DeleteCoupon(int bookingId)
        {
            var data = db.Bookings.Find(bookingId);
            if(data != null)
            {
                data.CouponId = 0;
                db.SaveChanges();
            }
            return "Deleted";
        }

        // Load Rooms Info
        public IList<RoomList> GetAllRooms ()
        {
            var data = db.RoomLists.ToList();
            return data;
        }

        // Send Query 
        public string SendQuery(EmailViewModal model)
        {
            // Sending Email to Admin
            string Message = "Sent";
            try
            {
                // Making a body
                string Body = "<h4>Name : " + model.Name + "</h4>";
                Body += "<h4>Email : " + model.Email + "</h4>";
                Body += "<h4>Phone No : " + model.Phone + "</h4>";
                Body += "<h4>Question / Query :</br></h4>";
                Body += "          <h4>" + model.Question + " </br></h4>";

                string senderEmail = "Booking@ahaji.sa";
                string senderPassword = "77777778*Ab";
                string To = model.Email;
                //string To1 = "m.hamzakhan717@gmail.com";

                using (MailMessage message = new MailMessage())
                {
                    string[] Add = {
                    To,
                    //To1
                };
                    message.From = new MailAddress(senderEmail, "Ahaji Booking");
                    for (int a = 0; a < Add.Length; a++)
                    {
                        if (!string.IsNullOrWhiteSpace(Add[a].ToString()))
                        {
                            message.To.Add(new MailAddress(Add[a].ToString()));
                        }
                    }

                    message.IsBodyHtml = true;
                    message.Subject = model.Title;
                    message.Body = Body;

                    SmtpClient smtp = new SmtpClient();

                    string host = "smtp.gmail.com";
                    if (host == "relay-hosting.secureserver.net")
                    {
                        smtp.Host = host;
                        smtp.Port = 25;
                        smtp.EnableSsl = false;
                        smtp.UseDefaultCredentials = false;
                    }
                    else
                    {
                        smtp.Host = host;//"smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    }
                    smtp.Send(message);

                    // generating email logs
                    var Email = new EmailHistory();
                    Email.SentOn = DateTime.Now;
                    Email.Status = "Sent";
                    Email.Title = model.Title;
                    Email.Id = 0;
                    db.EmailHistories.Add(Email);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }

        public string SendConfirmationEmail(ConfirmationEmailViewModal model)
        {
            // Sending Email to Admin
            string Message = "Sent";
            try
            {
                // Making a body
                string Body = "<h4>Customer Name : " + model.Name + "</h4>";
                Body += "<h4>Room Name : " + model.Room + "</h4>";
                Body += "<h4>Reserved Date & Time : " + model.ReservedDate + " " + model.Time + "</h4>";
                Body += "<h4>Total : "+ model.Total + "</h4><br><br>";
                Body += "<h4>Thank You for Reservesation</h4>";

                string senderEmail = "Booking@ahaji.sa";
                string senderPassword = "77777778*Ab";
                string To = model.Email;
                //string To1 = "m.hamzakhan717@gmail.com";

                using (MailMessage message = new MailMessage())
                {
                    string[] Add = {
                    To,
                    //To1
                };
                    message.From = new MailAddress(senderEmail, "Ahaji Booking");
                    for (int a = 0; a < Add.Length; a++)
                    {
                        if (!string.IsNullOrWhiteSpace(Add[a].ToString()))
                        {
                            message.To.Add(new MailAddress(Add[a].ToString()));
                        }
                    }

                    message.IsBodyHtml = true;
                    message.Subject = "Your Booking Confirmation";
                    message.Body = Body;

                    SmtpClient smtp = new SmtpClient();

                    string host = "smtp.gmail.com";
                    if (host == "relay-hosting.secureserver.net")
                    {
                        smtp.Host = host;
                        smtp.Port = 25;
                        smtp.EnableSsl = false;
                        smtp.UseDefaultCredentials = false;
                    }
                    else
                    {
                        smtp.Host = host;//"smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    }
                    smtp.Send(message);

                    // generating email logs
                    var Email = new EmailHistory();
                    Email.SentOn = DateTime.Now;
                    Email.Status = "Sent";
                    Email.Title = "Your Booking Confirmation";
                    Email.Id = 0;
                    db.EmailHistories.Add(Email);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }
    }
}

