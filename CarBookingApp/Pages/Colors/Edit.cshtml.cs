using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Colors
{
    public class EditModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        private readonly IGenericRepository<Color> _repository;
        public EditModel(IGenericRepository<Color> _repository)
        {
            this._repository = _repository;
        }

        [BindProperty]
        public Color Color { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Colors == null)
            {
                return NotFound();
            }

            var color =  await _context.Colors.FirstOrDefaultAsync(m => m.Id == id);
            if (color == null)
            {
                return NotFound();
            }
            Color = color;
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
            try
            {
                await _repository.Update(Color);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await ColorExistsAsync(Color.Id))
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

        private async Task<bool> ColorExistsAsync(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
