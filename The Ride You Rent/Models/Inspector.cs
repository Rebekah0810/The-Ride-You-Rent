using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace The_Ride_You_Rent.Models
{
    [Table("Inspector")]
    public partial class Inspector
    {
        public Inspector()
        {
            CarReturns = new HashSet<CarReturn>();
        }

        [Key]
        [Column("inspectorID")]
        [StringLength(50)]
        public string InspectorId { get; set; }
        [Column("inspectorName")]
        [StringLength(50)]
        public string InspectorName { get; set; }
        [Column("inspectorNumber")]
        [StringLength(50)]
        public string InspectorNumber { get; set; }
        [Column("inspectorEmail")]
        [StringLength(50)]
        public string InspectorEmail { get; set; }
        [Column("inspectorMobileNumber")]
        [StringLength(50)]
        public string InspectorMobileNumber { get; set; }

        [InverseProperty(nameof(CarReturn.InspectorNavigation))]
        public virtual ICollection<CarReturn> CarReturns { get; set; }
    }
}
