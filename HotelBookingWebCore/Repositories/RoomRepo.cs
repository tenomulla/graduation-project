using BookingWebsiteCore.Data;
using BookingWebsiteCore.Models;
using HotelBookingWebCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Repositories
{
    public class RoomRepo
    {
        BookingWebsite_DbContext db = new BookingWebsite_DbContext();

        // Get All Rooms
        public IList<RoomListViewModel> GetAllRooms()
        {
            List<PriceList> price = new List<PriceList>();
            List<RoomListViewModel> list = new List<RoomListViewModel>();
            var RoomData = db.RoomLists.ToList();
            foreach(var value in RoomData)
            {
                var priceData = db.PriceLists.Where(x => x.RoomId == value.Id).ToList();
                list.Add(new RoomListViewModel
                {
                    Id = value.Id,
                    ImagePath = value.ImagePath,
                    Name = value.Name,
                    RoomStory = value.RoomStory,
                    pList = priceData
                });
            }
            return list;
        }
        // Get Individual Room List
        public RoomListViewModel GetRoomListbyId(int Id)
        {
            List<PriceList> price = new List<PriceList>();
            RoomListViewModel list = new RoomListViewModel();
            var RoomData = db.RoomLists.Where(x=>x.Id == Id).FirstOrDefault();
            
                var priceData = db.PriceLists.Where(x => x.RoomId == RoomData.Id).ToList();
                list = new RoomListViewModel
                {
                    Id = RoomData.Id,
                    ImagePath = RoomData.ImagePath,
                    Name = RoomData.Name,
                    RoomStory = RoomData.RoomStory,
                    ColorCode = RoomData.ColorCode,
                    Langauge = RoomData.language,
                    NoofPlayers = RoomData.NoofPlayers,
                    pList = priceData
                };
            return list;
        }
        public string AddRooms(RoomListPostModel model, string Path)
        {
            string msg = "Failed";
            try
            {
                RoomList RList = new RoomList();
                PriceList PList = new PriceList();
                RList.ImagePath = Path == null ? "" : Path.Replace("wwwroot", "");
                RList.Name = model.Name;
                RList.RoomStory = model.RoomStory;
                RList.language = model.Language;
                RList.ColorCode = model.ColorCode;
                RList.NoofPlayers = model.NoofPlayers;
                var roomListResponse = db.RoomLists.Add(RList);
                db.SaveChanges();

                if (roomListResponse != null)
                {
                    // Insert into Price Table
                    for (var i = 0; i < 5; i++)
                    {
                        PList.NoOfRoom = model.noOfRoom[i];
                        PList.Price = model.price[i];
                        PList.RoomId = roomListResponse.Entity.Id;
                        PList.Id = 0;
                        db.PriceLists.Add(PList);
                        db.SaveChanges();
                    }
                    msg = "Added";
                }
            }
            catch(Exception ex)
            {

            }
            return msg;
        }

        // Updating Room
        public string UpdateRooms(RoomListPostModel model)
        {
            string msg = "Failed";
            try
            {
                RoomList RList = db.RoomLists.Where(x => x.Id == model.Id).FirstOrDefault();
                PriceList PList = new PriceList();
                RList.ImagePath = model.ImagePath == null ? "" : model.ImagePath.Replace("wwwroot", "");
                RList.Name = model.Name;
                RList.RoomStory = model.RoomStory;
                RList.language = model.Language;
                RList.ColorCode = model.ColorCode;
                RList.NoofPlayers = model.NoofPlayers;
                db.SaveChanges();
                // Remove from Price List where Room Primary Key = Price List Foreign Key
                var data = db.PriceLists.Where(x => x.RoomId == model.Id).ToList();
                foreach (var rem in data)
                {
                    db.PriceLists.Remove(rem);
                    db.SaveChanges();
                }

                // Insert into Price Table
                for (var i = 0; i < 5; i++)
                {
                    PList.NoOfRoom = model.noOfRoom[i];
                    PList.Price = model.price[i];
                    PList.Id = 0;
                    PList.RoomId = model.Id;
                    db.PriceLists.Add(PList);
                    db.SaveChanges();
                }
                msg = "Updated";
            }
            catch (Exception ex)
            {

            }
            return msg;
        }

        public string DeleteRoomById(int Id)
        {
            string msg = "Failed";
            // Fetching Room List for Delete
            var data = db.RoomLists.Where(x => x.Id == Id).FirstOrDefault();
            if(data != null)
            {
                // Deleting Room List
                db.RoomLists.Remove(data);
                db.SaveChanges();
                msg = "Deleted";
            }

            // Fetching Price List for Delete
            var PriceList = db.PriceLists.Where(x => x.RoomId == Id).ToList();
            if(PriceList != null)
            {
                foreach (var delPrice in PriceList)
                {
                    db.PriceLists.Remove(delPrice);
                    db.SaveChanges();
                }
                msg = "Deleted";
            }
            return msg;
        }
    }
}
