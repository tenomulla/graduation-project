using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    [Table("AppoinmentList")]
    public partial class AppoinmentList
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Time { get; set; }
    }
}
