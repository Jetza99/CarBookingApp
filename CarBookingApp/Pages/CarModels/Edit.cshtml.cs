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
using System.Runtime.InteropServices;

namespace CarBookingApp.Pages.CarModels
{
    public class EditModel : PageModel
    {
        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IGenericRepository<Make> _makesRepository;

        public EditModel(IGenericRepository<CarModel> _carModelRepository, IGenericRepository<Make> _makesRepository)
        {
            this._carModelRepository = _carModelRepository;
            this._makesRepository = _makesRepository;

        }
        [BindProperty]
        public CarModel CarModel { get; set; } = default!;
        public SelectList? Makes { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carmodel = await _carModelRepository.Get(id.Value);
            if (carmodel == null)
            {
                return NotFound();
            }

            CarModel = carmodel;
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
                await _carModelRepository.Update(CarModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CarModelExistsAsync(CarModel.Id))
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
            Makes = new SelectList(await _makesRepository.GetAll(), "Id", "Name");
        }

        private async Task<bool> CarModelExistsAsync(int id)
        {
            return await _carModelRepository.Exists(id);
        }
    }
}
