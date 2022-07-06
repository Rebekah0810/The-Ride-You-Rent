using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace The_Ride_You_Rent.Models
{
    [Table("carReturns")]
    public partial class CarReturn
    {
        [Key]
        [Column("returnID")]
        [StringLength(50)]
        public string ReturnId { get; set; }
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
        [Column("returnDate")]
        [StringLength(50)]
        public string ReturnDate { get; set; }
        [Column("rentalID")]
        [StringLength(50)]
        public string RentalId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty("CarReturns")]
        public virtual Car Car { get; set; }
        [ForeignKey(nameof(DriverId))]
        [InverseProperty("CarReturns")]
        public virtual Driver DriverNavigation { get; set; }
        [ForeignKey(nameof(InspectorId))]
        [InverseProperty("CarReturns")]
        public virtual Inspector InspectorNavigation { get; set; }
    }
}
