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
    public class IndexModel : PageModel
    {

        private readonly IGenericRepository<Color> _repository;
        public IndexModel(IGenericRepository<Color> _repository)
        {
            this._repository = _repository;
        }

        public IList<Color> Color { get;set; } = default!;

        public async Task OnGetAsync()
        {

            Color = await _repository.GetAll();

        }
        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null)
            {
                return NotFound();
            }
            await _repository.Delete(recordid.Value);

            return RedirectToPage();
        }

    }
}
