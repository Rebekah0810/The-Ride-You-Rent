using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using The_Ride_You_Rent.Data;
using The_Ride_You_Rent.Models;

namespace The_Ride_You_Rent.Pages.Inspectors
{
    public class DeleteModel : PageModel
    {
        private readonly The_Ride_You_Rent.Data.ApplicationDbContext _context;

        public DeleteModel(The_Ride_You_Rent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inspector Inspector { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inspector = await _context.Inspectors.FirstOrDefaultAsync(m => m.InspectorId == id);

            if (Inspector == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inspector = await _context.Inspectors.FindAsync(id);

            if (Inspector != null)
            {
                _context.Inspectors.Remove(Inspector);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
