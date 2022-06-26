using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    [Table("EmailHistory")]
    public partial class EmailHistory
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SentOn { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
    }
}
