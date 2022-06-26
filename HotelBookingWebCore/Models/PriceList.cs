using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    [Table("PriceList")]
    public partial class PriceList
    {
        [Key]
        public int Id { get; set; }
        public int? NoOfRoom { get; set; }
        public int? Price { get; set; }
        public int? RoomId { get; set; }
    }
}
