using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;

namespace CarBookingApp.Pages.Colors
{
    public class IndexModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Color> Color { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Colors != null)
            {
                Color = await _context.Colors.ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null || _context.Colors == null)
            {
                return NotFound();
            }
            var color = await _context.Colors.FindAsync(recordid);

            if (color != null)
            {
                _context.Colors.Remove(color);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}
