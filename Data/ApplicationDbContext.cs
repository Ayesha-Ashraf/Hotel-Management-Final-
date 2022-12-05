using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication5.Models.hotel> hotel { get; set; }
        public DbSet<WebApplication5.Models.Room> Room { get; set; }
        public DbSet<WebApplication5.Models.Customer> Customer { get; set; }
        public DbSet<WebApplication5.Models.Booking_Info> Booking_Info { get; set; }
    }
}
