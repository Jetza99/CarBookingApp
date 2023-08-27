﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingAppData;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public CreateModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Car Car { get; set; } = default!;
        public SelectList Makes { get; set; } = default!;
        public SelectList Models { get; set; } = default!;
        public SelectList Colors { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialData();
            return Page();
        }

        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cars == null || Car == null)
            {
                await LoadInitialData();
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetCarModels(int makeid)
        {
            var models = await _context.CarModels
                .Where(q => q.MakeId == makeid)
                .ToListAsync();

            return new JsonResult(models);
        }

        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _context.Makes.ToListAsync(), "Id", "Name");
            Colors = new SelectList(await _context.Colors.ToListAsync(), "Id", "Name");
        }
    }


}
