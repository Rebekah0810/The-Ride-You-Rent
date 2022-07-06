using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using The_Ride_You_Rent.Models;

namespace The_Ride_You_Rent.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Inspector> Inspectors { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<CarReturn> CarReturns { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
    }
}
