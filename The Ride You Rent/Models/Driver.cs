using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace The_Ride_You_Rent.Models
{
    [Table("Driver")]
    public partial class Driver
    {
        public Driver()
        {
            CarReturns = new HashSet<CarReturn>();
        }

        [Key]
        [Column("driverID")]
        [StringLength(50)]
        public string DriverId { get; set; }
        [Column("driverName")]
        [StringLength(50)]
        public string DriverName { get; set; }
        [Column("driverEmail")]
        [StringLength(50)]
        public string DriverEmail { get; set; }
        [Column("driverMobileNumber")]
        [StringLength(50)]
        public string DriverMobileNumber { get; set; }

        [InverseProperty(nameof(CarReturn.DriverNavigation))]
        public virtual ICollection<CarReturn> CarReturns { get; set; }
    }
}
