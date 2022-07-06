using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace The_Ride_You_Rent.Models
{
    [Table("Car")]
    public partial class Car
    {
        public Car()
        {
            CarReturns = new HashSet<CarReturn>();
        }

        [Key]
        [Column("carID")]
        [StringLength(50)]
        public string CarId { get; set; }
        [Column("carMake")]
        [StringLength(50)]
        public string CarMake { get; set; }
        [Column("carModel")]
        [StringLength(50)]
        public string CarModel { get; set; }
        [Column("carBodyType")]
        [StringLength(50)]
        public string CarBodyType { get; set; }
        [Column("carkilometersTravelled")]
        public int? CarkilometersTravelled { get; set; }
        [Column("carServiceKilometers")]
        public int? CarServiceKilometers { get; set; }
        [Required]
        [Column("carAvaliablityStatus")]
        [StringLength(50)]
        public string CarAvaliablityStatus { get; set; }

        [InverseProperty(nameof(CarReturn.Car))]
        public virtual ICollection<CarReturn> CarReturns { get; set; }
    }
}
