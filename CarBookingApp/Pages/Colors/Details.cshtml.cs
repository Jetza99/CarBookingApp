using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Colors
{
    public class DetailsModel : PageModel
    {
        private readonly IGenericRepository<Color> _repository;
        public DetailsModel(IGenericRepository<Color> _repository)
        {
            this._repository = _repository;
        }

        public Color Color { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await _repository.Get(id.Value);
            if (color == null)
            {
                return NotFound();
            }
            else 
            {
                Color = color;
            }
            return Page();
        }
    }
}
