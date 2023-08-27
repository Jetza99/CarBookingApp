using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingAppData;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.CarModels
{
    public class CreateModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialData();
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; } = default!;
        public SelectList? Makes { get; private set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CarModels == null || CarModel == null)
            {
                await LoadInitialData();
                return Page();
            }

            _context.CarModels.Add(CarModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
        }
    }
}
