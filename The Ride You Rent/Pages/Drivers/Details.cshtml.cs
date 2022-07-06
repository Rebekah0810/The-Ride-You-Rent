using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Ride_You_Rent.Data;
using The_Ride_You_Rent.Models;

namespace The_Ride_You_Rent.Pages.Drivers
{
    public class DetailsModel : PageModel
    {
        private readonly The_Ride_You_Rent.Data.ApplicationDbContext _context;

        public DetailsModel(The_Ride_You_Rent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Driver Driver { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = await _context.Drivers.FirstOrDefaultAsync(m => m.DriverId == id);

            if (Driver == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
