using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ICarRepository _carRepository;
        public DetailsModel(ICarRepository _carRepository)
        {
            this._carRepository = _carRepository;
        }

        public Car Car { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carRepository.GetCarWithDetail(id.Value);


            if (car == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
