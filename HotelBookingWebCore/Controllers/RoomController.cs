using HotelBookingWebCore.Models;
using HotelBookingWebCore.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Controllers
{
    public class RoomController : Controller
    {
        RoomRepo repo = new RoomRepo();
        public IActionResult RoomList()
        {
            return View("room-list");
        }

        // Get All Rooms
        public JsonResult GetAllRooms()
        {
            return Json(repo.GetAllRooms());
        }

        // Add New Room
        public async Task<JsonResult> AddNewRoom(RoomListPostModel model)
        {
            string Path = model.ImagePath;
            string response = await Task.Run(() => repo.AddRooms(model, Path));
            return Json(response);
        }

        [HttpPost]
        public async Task<string> AddNewImage()
        {
            IFormFile files = Request.Form.Files[0];
            string filePath = string.Empty;
            long size = files.Length;
            if (files.Length > 0)
            {
                filePath = Path.Combine("wwwroot/images/RoomImages/") + Path.GetRandomFileName().Replace(".","-") + Path.GetExtension(files.FileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await Task.Run(() => files.CopyTo(stream));
                }
            }
            return filePath;
        }

        // Fetch Individual Room List
        public JsonResult FetchRoomListById(int Id)
        {
            return Json(repo.GetRoomListbyId(Id));
        }

        // Updating Room
        public JsonResult UpdateRoom(RoomListPostModel model)
        {
            string response = repo.UpdateRooms(model);
            return Json(response);
        }

        // Delete Room
        public JsonResult DeleteRoomById(int Id)
        {
            return Json(repo.DeleteRoomById(Id));
        }
    }
}
