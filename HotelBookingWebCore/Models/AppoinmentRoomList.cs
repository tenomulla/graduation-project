using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    [Table("AppoinmentRoomList")]
    public partial class AppoinmentRoomList
    {
        [Key]
        public int Id { get; set; }
        public string Room { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }
        public int? AppoinmentId { get; set; }
    }
}
