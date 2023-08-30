using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarBookingAppData;
using CarBookingAppRepositories.Contracts;

namespace CarBookingApp.Pages.Cars
{
    public class EditModel : PageModel
    {

        private readonly IGenericRepository<Car> _carRepository;
        private readonly IGenericRepository<Make> _makeRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IGenericRepository<Color> _colorRepository;
        public EditModel(IGenericRepository<Car> _carRepository,
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
        public SelectList? Makes { get; set; }
        public SelectList? Models { get; private set; }
        public SelectList? Colors { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carRepository.Get(id.Value);

            if (car == null)
            {
                return NotFound();
            }
         

            await LoadInitialData();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }
            try
            {
                await _carRepository.Update(Car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CarExistsAsync(Car.Id))
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
        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _makeRepository.GetAll(), "Id", "Name");
            Models = new SelectList(await _carModelRepository.GetAll(), "Id", "Name");
            Colors = new SelectList(await _colorRepository.GetAll(), "Id", "Name");
        }

        private async Task<bool> CarExistsAsync(int id)
        {
            return await _carRepository.Exists(id);
        }
    }
}
