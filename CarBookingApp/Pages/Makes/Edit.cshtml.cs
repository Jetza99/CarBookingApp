﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Makes
{
    public class EditModel : PageModel
    {

        private readonly IGenericRepository<Make> _repository;
        public EditModel(IGenericRepository<Make> _repository)
        {
            this._repository = _repository;
        }

        [BindProperty]
        public Make Make { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _repository.Get(id.Value);
            if (make == null)
            {
                return NotFound();
            }
            Make = make;
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
                await _repository.Update(Make);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await MakeExistsAsync(Make.Id))
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

        private async Task<bool> MakeExistsAsync(int id)
        {
          return await _repository.Exists(id);
        }
    }
}
