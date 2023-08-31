using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CarBookingApp.Pages.Cars
{

    public class indexModel : PageModel
    {
        private readonly ICarRepository _carRepository;
        public indexModel(ICarRepository _carRepository)
        {
            this._carRepository = _carRepository;
        }

        public IList<Car> Cars { get;set; } = default!;

        public async Task OnGetAsync()
        {

                Cars = await _carRepository.GetCarListWithDetails();

        }

        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null)
            {
                return NotFound();
            }

            await _carRepository.Delete(recordid.Value);

            return RedirectToPage();
        }
    }
}
