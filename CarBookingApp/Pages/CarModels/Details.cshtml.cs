using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;

namespace CarBookingApp.Pages.CarModels
{
    public class DetailsModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public DetailsModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

      public CarModel CarModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CarModels == null)
            {
                return NotFound();
            }

            var carmodel = await _context.CarModels.FirstOrDefaultAsync(m => m.Id == id);
            if (carmodel == null)
            {
                return NotFound();
            }
            else 
            {
                CarModel = carmodel;
            }
            return Page();
        }
    }
}
