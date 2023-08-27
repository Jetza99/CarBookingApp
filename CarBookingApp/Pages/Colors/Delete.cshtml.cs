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
    public class DeleteModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public DeleteModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Color Color { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Colors == null)
            {
                return NotFound();
            }

            var color = await _context.Colors.FirstOrDefaultAsync(m => m.Id == id);

            if (color == null)
            {
                return NotFound();
            }
            else 
            {
                Color = color;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Colors == null)
            {
                return NotFound();
            }
            var color = await _context.Colors.FindAsync(id);

            if (color != null)
            {
                Color = color;
                _context.Colors.Remove(Color);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
