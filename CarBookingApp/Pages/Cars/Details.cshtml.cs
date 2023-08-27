﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;

namespace CarBookingApp.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly CarBookingAppData.CarBookingAppDbContext _context;

        public DetailsModel(CarBookingAppData.CarBookingAppDbContext context)
        {
            _context = context;
        }

      public Car Car { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(q => q.Make)
                .Include(q => q.Color)
                .Include(q => q.CarModel)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (car == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
            }
            return Page();
        }
    }
}
