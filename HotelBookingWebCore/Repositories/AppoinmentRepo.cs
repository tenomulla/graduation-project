using BookingWebsiteCore.Data;
using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Repositories
{
    public class AppoinmentRepo
    {
        BookingWebsite_DbContext db = new BookingWebsite_DbContext();

        // View All Appoinment
        public List<AppoinmentList> GetAllAppoinment()
        {
            List<AppoinmentList> list = new List<AppoinmentList>();
            list = db.AppoinmentLists.Select(x=>new AppoinmentList { 
                Id = x.Id,
                Time = x.Time
            }).ToList();
            return list;
        }

        // Add New Appoinment
        public string AddNewAppoinment(string Time)
        {
            string msg = "Failed";
            var appoinment = new AppoinmentList();
            appoinment.Time = Time;
            var data = db.AppoinmentLists.Add(appoinment);
            db.SaveChanges();
            if(data != null)
            {
                msg = "Added";
            }
            return msg;
        }

        // Update Appoinment List
        public string UpdateAppoinment(AppoinmentViewModel model)
        {
            string msg = "Failed";
            var appoinment = db.AppoinmentLists.Where(x => x.Id == model.Id).FirstOrDefault();
            AppoinmentRoomList aplist = new AppoinmentRoomList();
            if (appoinment != null)
            {
                var dt = db.AppoinmentRoomLists.Where(x => x.AppoinmentId == appoinment.Id).ToList();
                if(dt != null)
                {
                    // Deleteing Appoinment Room List
                    foreach (var del in dt)
                    {
                        db.AppoinmentRoomLists.Remove(del);
                        db.SaveChanges();
                    }

                    // Adding again Appoinment Room List
                    foreach (var value in model.RoomArr)
                    {
                        aplist.AppoinmentId = appoinment.Id;
                        aplist.Room = value;
                        aplist.Status = model.Status;
                        aplist.ToDate = model.ToDate;
                        aplist.FromDate = model.FromDate;
                        aplist.Id = 0;
                        db.AppoinmentRoomLists.Add(aplist);
                        db.SaveChanges();
                    }
                    msg = "Updated";
                }
            }
            return msg;
        }

        // Get Appoinment By Id
        public AppoinmentListViewModel GetAppoinmentById(int Id)
        {
            AppoinmentListViewModel apLis = new AppoinmentListViewModel();
            var list = db.AppoinmentLists.Where(x => x.Id == Id).FirstOrDefault();
            if(list != null)
            {
                var roomList = db.AppoinmentRoomLists.Where(x => x.AppoinmentId == list.Id).ToList();
                apLis.Id = list.Id;
                apLis.RoomArr = roomList;
                apLis.Time = list.Time;
            }
            return apLis;
        }
    }
}
