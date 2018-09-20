using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Airports
{
    public class IndexModel : PageModel
    {
        private readonly IAirportRepository _repository;

        public IndexModel(IAirportRepository repository)
        {
            _repository = repository;
        }

        public IList<Airport> Airports { get; set; }

        public async Task OnGetAsync()
        {
            Airports = await _repository.GetAll();
        }
    }
}
