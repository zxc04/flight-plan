using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Airports
{
    public class EditModel : PageModel
    {
        private readonly IAirportRepository _repository;

        public EditModel(IAirportRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Airport Airport { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airport = await _repository.Get(id);

            if (Airport == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _repository.CreateOrUpdate(Airport);

            if (result == null)
                return NotFound();

            return RedirectToPage("./Details", new { id = result });
        }
    }
}
