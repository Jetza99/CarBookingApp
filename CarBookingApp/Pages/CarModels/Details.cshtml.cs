using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.CarModels
{
    public class DetailsModel : PageModel
    { 
        private readonly ICarModelRepository _repository;
        public DetailsModel(ICarModelRepository _repository)
        {
            this._repository = _repository;
        }

        public CarModel CarModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel = await _repository.GetCarModelWithDetails(id.Value);

            if (CarModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
