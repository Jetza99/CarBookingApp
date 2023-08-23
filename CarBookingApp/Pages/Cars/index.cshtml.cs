using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;

namespace CarBookingApp.Pages.Cars
{
    public class indexModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public indexModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cars != null)
            {
                Cars = await _context.Cars.ToListAsync();
            }
        }
    }
}
