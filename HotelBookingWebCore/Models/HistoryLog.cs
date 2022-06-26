using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsiteCore.Models
{
    public partial class HistoryLog
    {
        [Key]
        public int Id { get; set; }
        public int? AddedBy { get; set; }
        [StringLength(50)]
        public string AddedByName { get; set; }
        public string Description { get; set; }
        public int? BookingId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
    }
}
