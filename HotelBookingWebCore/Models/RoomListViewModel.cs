using BookingWebsiteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Models
{
    public class RoomListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomStory { get; set; }
        public string ImagePath { get; set; }

        public string ColorCode { get; set; }
        public string NoofPlayers { get; set; }
        public string Langauge { get; set; }
        public List<PriceList> pList { get; set; }
    }

    public class RoomListPostModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomStory { get; set; }
        public string ImagePath { get; set; }
        public string ColorCode { get; set; }
        public string Language { get; set; }
        public string NoofPlayers { get; set; }
        public int[] noOfRoom { get; set; }
        public int[] price { get; set; }
    }
}
