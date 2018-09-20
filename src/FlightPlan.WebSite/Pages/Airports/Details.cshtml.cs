using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Airports
{
    public class DetailsModel : PageModel
    {
        private readonly IAirportRepository _repository;

        public DetailsModel(IAirportRepository repository)
        {
            _repository = repository;
        }

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
    }
}
