using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using The_Ride_You_Rent.Data;
using The_Ride_You_Rent.Models;

namespace The_Ride_You_Rent.Pages.carReturns
{
    public class CreateModel : PageModel
    {
        private readonly The_Ride_You_Rent.Data.ApplicationDbContext _context;

        public CreateModel(The_Ride_You_Rent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
        ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
        ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId");
            return Page();
        }

        [BindProperty]
        public CarReturn CarReturn { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CarReturns.Add(CarReturn);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
