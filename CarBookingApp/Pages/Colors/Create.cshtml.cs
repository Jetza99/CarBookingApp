using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Colors
{
    public class CreateModel : PageModel
    {
        private readonly IGenericRepository<Color> _repository;
        public CreateModel(IGenericRepository<Color> _repository)
        {
            this._repository = _repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Color Color { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.Insert(Color);

            return RedirectToPage("./Index");
        }
    }
}
