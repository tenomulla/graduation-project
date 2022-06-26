using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        [StringLength(50)]
        public string ProfileImage { get; set; }
        [StringLength(50)]
        public string UserType { get; set; }
        public bool? isActive { get; set; }
        public int? Sno { get; set; }
    }
}
