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
    public class IndexModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public IndexModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<CarModel> CarModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CarModels != null)
            {
                CarModel = await _context.CarModels.ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null || _context.Makes == null)
            {
                return NotFound();
            }
            var model = await _context.CarModels.FindAsync(recordid);

            if (model != null)
            {
                _context.CarModels.Remove(model);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
