﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingAppData;

namespace CarBookingApp.Pages.Colors
{
    public class CreateModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
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
          if (!ModelState.IsValid || _context.Colors == null || Color == null)
            {
                return Page();
            }

            _context.Colors.Add(Color);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
