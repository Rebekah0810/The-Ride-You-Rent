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
    public class IndexModel : PageModel
    {
        private readonly The_Ride_You_Rent.Data.ApplicationDbContext _context;

        public IndexModel(The_Ride_You_Rent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Driver> Driver { get;set; }

        public async Task OnGetAsync()
        {
            Driver = await _context.Drivers.ToListAsync();
        }
    }
}
