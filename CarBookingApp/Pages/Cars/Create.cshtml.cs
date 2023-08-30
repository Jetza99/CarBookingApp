using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingAppData;
using Microsoft.EntityFrameworkCore;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Cars
{
    public class CreateModel : PageModel
    {

        private readonly IGenericRepository<Car> _carRepository;
        private readonly IGenericRepository<Make> _makeRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IGenericRepository<Color> _colorRepository;
        public CreateModel(IGenericRepository<Car> _carRepository,
                           IGenericRepository<Make> _makeRepository,
                           ICarModelRepository _carModelRepository,
                           IGenericRepository<Color> _colorRepository)
        {
            this._carRepository = _carRepository;
            this._makeRepository = _makeRepository;
            this._carModelRepository = _carModelRepository;
            this._colorRepository = _colorRepository;
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
          if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }

            await _carRepository.Insert(Car);

            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetCarModels(int makeid)
        {
            return new JsonResult(await _carModelRepository.GetCarModelsByMake(makeid));
        }

        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _makeRepository.GetAll(), "Id", "Name");
            Models = new SelectList(await _carModelRepository.GetAll(), "Id", "Name");
            Colors = new SelectList(await _colorRepository.GetAll(), "Id", "Name");
        }
    }


}
