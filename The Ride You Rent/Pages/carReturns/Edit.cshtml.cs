using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Ride_You_Rent.Data;
using The_Ride_You_Rent.Models;

namespace The_Ride_You_Rent.Pages.carReturns
{
    public class EditModel : PageModel
    {
        private readonly The_Ride_You_Rent.Data.ApplicationDbContext _context;

        public EditModel(The_Ride_You_Rent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
           ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
           ViewData["InspectorId"] = new SelectList(_context.Inspectors, "InspectorId", "InspectorId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarReturnExists(CarReturn.ReturnId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarReturnExists(string id)
        {
            return _context.CarReturns.Any(e => e.ReturnId == id);
        }
    }
}
