using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Makes
{
    public class DetailsModel : PageModel
    {

        private readonly IGenericRepository<Make> _repository;
        public DetailsModel(IGenericRepository<Make> _repository)
        {
            this._repository = _repository;
        }

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
            else 
            {
                Make = make;
            }
            return Page();
        }
    }
}
