using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    [Table("RoomList")]
    public partial class RoomList
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomStory { get; set; }
        public string ImagePath { get; set; }
        public string ColorCode { get; set; }
        [StringLength(50)]
        public string language { get; set; }
        [StringLength(50)]
        public string NoofPlayers { get; set; }
    }
}
