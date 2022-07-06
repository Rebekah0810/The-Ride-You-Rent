using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Ride_You_Rent.Data;
using The_Ride_You_Rent.Models;

namespace The_Ride_You_Rent.Pages.carReturns
{
    public class DetailsModel : PageModel
    {
        private readonly The_Ride_You_Rent.Data.ApplicationDbContext _context;

        public DetailsModel(The_Ride_You_Rent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CarReturn CarReturn { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarReturn = await _context.CarReturns
                .Include(c => c.Car)
                .Include(c => c.DriverNavigation)
                .Include(c => c.InspectorNavigation).FirstOrDefaultAsync(m => m.ReturnId == id);

            if (CarReturn == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
