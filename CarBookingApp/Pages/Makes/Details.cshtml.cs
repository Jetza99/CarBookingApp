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
    public class DetailsModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public DetailsModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

      public Make Make { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Makes == null)
            {
                return NotFound();
            }

            var make = await _context.Makes.FirstOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }
            else 
            {
                Make = make;
            }
            return Page();
        }
    }
}
