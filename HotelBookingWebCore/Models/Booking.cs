using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    public partial class Booking
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Room { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BookedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EnteredDate { get; set; }
        [StringLength(50)]
        public string Time { get; set; }
        [StringLength(50)]
        public string GuestName { get; set; }
        [StringLength(50)]
        public string PhoneNo { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public int? Size { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Total { get; set; }
        public int? CouponId { get; set; }
        [StringLength(500)]
        public string PaymentCode { get; set; }
        public string Comment { get; set; }
    }
}
