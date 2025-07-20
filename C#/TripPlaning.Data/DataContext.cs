using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripPlaning.Core.DTO;
using TripPlaning.Core.Model;

namespace TripPlaning.Data
{
    public class DataContext :DbContext
    {
       public DbSet<Trip> Trips { get; set; }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<StopoverPlace> StopoverPlaces { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<OpeningHours> OpeningHours { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OpeningHours>()
        //        .HasOne(o => o.place)
        //        .WithMany(p => p.OpeningHours)
        //        .HasForeignKey(o => o.PlaceId)
        //        .OnDelete(DeleteBehavior.Cascade);  // מחיקה Cascading: אם נמחק מקום -> נמחקות שעות הפתיחה שלו
        //}
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
    
}
