using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Flights
{
    public class DeleteModel : PageModel
    {
        private readonly IFlightRepository _repository;

        public DeleteModel(IFlightRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Flight Flight { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _repository.Get(id);

            if (Flight == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
