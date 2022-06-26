using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    [Table("CoupnList")]
    public partial class CoupnList
    {
        [Key]
        public int Id { get; set; }
        public int? Duration { get; set; }
        [StringLength(50)]
        public string DayMinHour { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RelaseDate { get; set; }
        public int? DiscountPercent { get; set; }
    }
}
