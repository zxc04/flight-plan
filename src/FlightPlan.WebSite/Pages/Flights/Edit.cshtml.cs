using FlightPlan.Application.Domain;
using FlightPlan.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace FlightPlan.WebSite.Pages.Flights
{
    public class EditModel : PageModel
    {
        private readonly IFlightRepository _repository;
        private readonly IAirportRepository _airportRepository;
        private readonly IPlaneRepository _planeRepository;

        public EditModel(IFlightRepository repository, IAirportRepository airportRepository, IPlaneRepository planeRepository)
        {
            _repository = repository;
            _airportRepository = airportRepository;
            _planeRepository = planeRepository;
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

            var airports = await _airportRepository.GetAll();
            var planes = await _planeRepository.GetAll();

            ViewData["ArrivalAirportId"] = new SelectList(airports, "Id", "Name");
            ViewData["DepartureAirportId"] = new SelectList(airports, "Id", "Name");
            ViewData["PlaneId"] = new SelectList(planes, "Id", "Model");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Flight.DepartureAirport = await _airportRepository.Get(Flight.DepartureAirport.Id);
            Flight.ArrivalAirport = await _airportRepository.Get(Flight.ArrivalAirport.Id);
            Flight.Plane = await _planeRepository.Get(Flight.Plane.Id);

            var result = await _repository.CreateOrUpdate(Flight);

            if (result == null)
                return NotFound();

            return RedirectToPage("./Details", new { id = result });
        }
    }
}
