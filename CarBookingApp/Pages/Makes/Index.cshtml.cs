using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;

namespace CarBookingApp.Pages.Makes
{
    public class IndexModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Make> Make { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Makes != null)
            {
                Make = await _context.Makes.ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostDelete(int? makeid)
        {
            if (makeid == null || _context.Makes == null)
            {
                return NotFound();
            }
            var make = await _context.Makes.FindAsync(makeid);

            if (make != null)
            {
                _context.Makes.Remove(make);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
