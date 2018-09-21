using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Flights
{
    public class IndexModel : PageModel
    {
        private readonly IFlightRepository _repository;

        public IndexModel(IFlightRepository repository)
        {
            _repository = repository;
        }

        public IList<Flight> Flights { get; set; }

        public async Task OnGetAsync()
        {
            Flights = await _repository.GetAll();
        }
    }
}
