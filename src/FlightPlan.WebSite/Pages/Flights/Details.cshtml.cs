using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Flights
{
    public class DetailsModel : PageModel
    {
        private readonly IFlightRepository _repository;

        public DetailsModel(IFlightRepository repository)
        {
            _repository = repository;
        }

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
    }
}
