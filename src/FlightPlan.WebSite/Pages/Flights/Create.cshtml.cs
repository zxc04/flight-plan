using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Flights
{
    public class CreateModel : PageModel
    {
        private readonly IFlightRepository _repository;
        private readonly IAirportRepository _airportRepository;
        private readonly IPlaneRepository _planeRepository;

        public CreateModel(IFlightRepository repository, IAirportRepository airportRepository, IPlaneRepository planeRepository)
        {
            _repository = repository;
            _airportRepository = airportRepository;
            _planeRepository = planeRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var airports = await _airportRepository.GetAll();
            var planes = await _planeRepository.GetAll();

            ViewData["ArrivalAirportId"] = new SelectList(airports, "Id", "Name");
            ViewData["DepartureAirportId"] = new SelectList(airports, "Id", "Name");
            ViewData["PlaneId"] = new SelectList(planes, "Id", "Model");

            return Page();
        }

        [BindProperty]
        public Flight Flight { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.CreateOrUpdate(Flight);

            return RedirectToPage("./Index");
        }
    }
}