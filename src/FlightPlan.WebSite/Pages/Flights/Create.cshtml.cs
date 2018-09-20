using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlightPlan.Sql.Entities;

namespace FlightPlan.WebSite.Pages.Flights
{
    public class CreateModel : PageModel
    {
        private readonly FlightPlan.Sql.Entities.DatabaseContext _context;

        public CreateModel(FlightPlan.Sql.Entities.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ArrivalAirportId"] = new SelectList(_context.Airports, "Id", "Name");
        ViewData["DepartureAirportId"] = new SelectList(_context.Airports, "Id", "Name");
        ViewData["PlaneId"] = new SelectList(_context.Planes, "Id", "Model");
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

            _context.Flights.Add(Flight);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}