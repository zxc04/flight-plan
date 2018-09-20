using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightPlan.Sql.Entities;

namespace FlightPlan.WebSite.Pages.Flights
{
    public class EditModel : PageModel
    {
        private readonly FlightPlan.Sql.Entities.DatabaseContext _context;

        public EditModel(FlightPlan.Sql.Entities.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Flight Flight { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight = await _context.Flights
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .Include(f => f.Plane).FirstOrDefaultAsync(m => m.Id == id);

            if (Flight == null)
            {
                return NotFound();
            }
           ViewData["ArrivalAirportId"] = new SelectList(_context.Airports, "Id", "Id");
           ViewData["DepartureAirportId"] = new SelectList(_context.Airports, "Id", "Id");
           ViewData["PlaneId"] = new SelectList(_context.Planes, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(Flight.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FlightExists(Guid id)
        {
            return _context.Flights.Any(e => e.Id == id);
        }
    }
}
