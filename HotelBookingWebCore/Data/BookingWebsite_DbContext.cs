using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BookingWebsiteCore.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookingWebsiteCore.Data
{
    public partial class BookingWebsite_DbContext : DbContext
    {
        public virtual DbSet<AppoinmentList> AppoinmentLists { get; set; }
        public virtual DbSet<AppoinmentRoomList> AppoinmentRoomLists { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CoupnList> CoupnLists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<EmailHistory> EmailHistories { get; set; }
        public virtual DbSet<HistoryLog> HistoryLogs { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<RoomList> RoomLists { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //public BookingWebsite_DbContext(DbContextOptions<BookingWebsite_DbContext> options) : base(options)
        //{
        //}

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FL2LE4E;Initial Catalog=BookingWebsite_Db;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
