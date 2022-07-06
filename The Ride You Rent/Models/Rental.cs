using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace The_Ride_You_Rent.Models
{
    [Table("Rental")]
    public partial class Rental
    {
        [Key]
        [Column("rentalID")]
        [StringLength(50)]
        public string RentalId { get; set; }
        [Column("carID")]
        [StringLength(50)]
        public string CarId { get; set; }
        [Column("inspector")]
        [StringLength(50)]
        public string Inspector { get; set; }
        [Column("inspectorID")]
        [StringLength(50)]
        public string InspectorId { get; set; }
        [Column("driver")]
        [StringLength(50)]
        public string Driver { get; set; }
        [Column("driverID")]
        [StringLength(50)]
        public string DriverId { get; set; }
        [Column("rentalFee")]
        [StringLength(50)]
        public string RentalFee { get; set; }
        [Column("rentalStartDate")]
        [StringLength(50)]
        public string RentalStartDate { get; set; }
        [Column("rentalEndDate")]
        [StringLength(50)]
        public string RentalEndDate { get; set; }
    }
}
